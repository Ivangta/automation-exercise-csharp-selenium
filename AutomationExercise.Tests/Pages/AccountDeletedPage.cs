using AutomationExercise.Tests.Base;
using OpenQA.Selenium;

namespace AutomationExercise.Tests.Pages
{
    internal class AccountDeletedPage : BasePage
    {
        //Account deleted
        private readonly By accountDeletedTitle = By.CssSelector("h2[data-qa='account-deleted']");

        //Continue
        private readonly By continueButton = By.CssSelector("a[data-qa='continue-button']");
        public AccountDeletedPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
