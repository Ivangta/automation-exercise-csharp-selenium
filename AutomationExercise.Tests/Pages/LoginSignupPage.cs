using AutomationExercise.Tests.Base;
using OpenQA.Selenium;

namespace AutomationExercise.Tests.Pages
{
    public class LoginSignupPage : BasePage
    {
        private const string Url = "https://automationexercise.com/login";

        private readonly By emailLoginText = By.CssSelector("input[data-qa='login-email']");

        private readonly By passwordLoginText = By.CssSelector("input[data-qa='login-password']");

        private readonly By loginButton = By.CssSelector("button[data-qa='login-button']");

        private readonly By loginErrorMessage = By.CssSelector("form[action='/login'] p");

        private readonly By nameSignupText = By.CssSelector("input[data-qa='signup-name']");

        private readonly By emailSignupText = By.CssSelector("input[data-qa='signup-email']");

        public LoginSignupPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open()
        {
            NavigateTo(Url);
        }

        public void Signup(string name, string email)
        {
            EnterText(nameSignupText, name);
            EnterText(emailSignupText, email);
            Click(loginButton);
        }

        public void Login(string email, string password)
        {
            EnterText(emailLoginText, email);
            EnterText(passwordLoginText, email);
            Click(loginButton);
        }

        public string GetLoginErrorMessage()
        {
            return GetText(loginErrorMessage);
        }
    }
}
