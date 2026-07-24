using OpenQA.Selenium;

namespace AutomationExercise.Tests.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        private const string Url = "https://automationexercise.com/";
        private readonly By logo = By.CssSelector("img[alt='Website for automation practice']");
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public bool IsLogoDisplayed()
        {
            return driver.FindElement(logo).Displayed;
        }
    }
}
