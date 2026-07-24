using OpenQA.Selenium;

namespace AutomationExercise.Tests.Base
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement Find(By locator)
        {
            return driver.FindElement(locator);
        }

        protected void Click(By locator)
        {
            Find(locator).Click();
        }

        protected void EnterText(By locator, string text)
        {
            IWebElement element = Find(locator);

            element.Clear();
            element.SendKeys(text);
        }

        protected string GetText(By locator)
        {
            return Find(locator).Text;
        }

        protected bool IsDisplayed(By locator)
        {
            return Find(locator).Displayed;
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
