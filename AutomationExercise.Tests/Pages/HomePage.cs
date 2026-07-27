using AutomationExercise.Tests.Base;
using OpenQA.Selenium;

namespace AutomationExercise.Tests.Pages
{
    public class HomePage : BasePage
    {
        //Url
        private const string Url = "https://automationexercise.com/";

        //Logo
        private readonly By logo = By.CssSelector("img[alt='Website for automation practice']");

        //Logged in as "user"
        private readonly By loggedInAsLabel = By.XPath("//a[contains(., 'Logged in as')]");

        //Delete account
        private readonly By deleteAccountButton = By.CssSelector("a[href='/delete_account']");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            NavigateTo(Url);
        }

        public bool IsLogoDisplayed()
        {
            return IsDisplayed(logo);
        }

        public string GetLoggedInAsText()
        {
            return GetText(loggedInAsLabel);
        }
    }
}
