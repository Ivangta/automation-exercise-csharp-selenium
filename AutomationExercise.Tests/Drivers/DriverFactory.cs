using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationExercise.Tests.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();

            IWebDriver driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
