using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Tests.Base
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        protected readonly WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException));
        }

        protected IWebElement WaitUntilVisible(By locator)
        {
            return wait.Until(driver =>
            {
                IWebElement element = driver.FindElement(locator);

                return element.Displayed
                ? element
                : null;
            })!;
        }

        protected IWebElement WaitUntilClickable(By locator)
        {
            return wait.Until(driver =>
            {
                IWebElement element = driver.FindElement(locator);

                return element.Displayed && element.Enabled
                ? element
                : null;
            })!;
        }

        protected IWebElement Find(By locator)
        {
            return wait.Until(driver =>
                driver.FindElement(locator));
        }

        protected void Click(By locator)
        {
            WaitUntilClickable(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            IWebElement element = WaitUntilVisible(locator);

            element.Clear();
            if (!string.IsNullOrEmpty(text))
            {
                element.SendKeys(text);
            }
        }

        protected string GetText(By locator)
        {
            return WaitUntilVisible(locator).Text;
        }

        protected bool IsDisplayed(By locator)
        {
            return WaitUntilVisible(locator).Displayed;
        }

        protected string? GetAttribute(By locator, string attributeName)
        {
            return Find(locator).GetAttribute(attributeName);
        }

        protected bool IsEnabled(By locator)
        {
            return Find(locator).Enabled;
        }

        protected void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }


    }
}
