using AutomationExercise.Tests.Base;
using OpenQA.Selenium;

namespace AutomationExercise.Tests.Pages
{
    public class CookieBanner : BasePage
    {
        private readonly By acceptButton = By.CssSelector("button.fc-cta-consent");

        public CookieBanner(IWebDriver driver) : base(driver)
        {
        }

        public void AcceptCookies()
        {
            Click(acceptButton);
        }
    }
}
