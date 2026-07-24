using AutomationExercise.Tests.Base;
using OpenQA.Selenium;

namespace AutomationExercise.Tests.Pages
{
    public class LoginPage : BasePage
    {
        private const string Url = "https://automationexercise.com/login";

        private readonly By emailText = By.CssSelector("input[data-qa='login-email']");

        private readonly By passwordText = By.CssSelector("input[data-qa='login-password']");

        private readonly By loginButton = By.CssSelector("button[data-qa='login-button']");

        private readonly By loginErrorMessage = By.CssSelector("form[action='/login'] p");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            NavigateTo(Url);
        }

        public void Login(string email, string password)
        {
            EnterText(emailText, email);
            EnterText(passwordText, email);
            Click(loginButton);
        }

        public string GetLoginErrorMessage()
        {
            return GetText(loginErrorMessage);
        }
    }
}
