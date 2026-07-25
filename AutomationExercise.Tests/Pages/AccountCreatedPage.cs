using AutomationExercise.Tests.Base;
using OpenQA.Selenium;

namespace AutomationExercise.Tests.Pages
{
    public class AccountCreatedPage : BasePage
    {
        //Account created
        private readonly By accountCreatedTitle = By.CssSelector("h2[data-qa='account-created']");

        //Continue
        private readonly By continueButton = By.CssSelector("a[data-qa='continue-button']");

        public AccountCreatedPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
