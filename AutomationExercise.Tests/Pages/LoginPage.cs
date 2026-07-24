using AutomationExercise.Tests.Base;
using OpenQA.Selenium;

namespace AutomationExercise.Tests.Pages
{
    public class LoginPage : BasePage
    {
        private const string Url = "https://automationexercise.com/";



        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
