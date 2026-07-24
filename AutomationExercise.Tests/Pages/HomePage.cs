using AutomationExercise.Tests.Base;
using OpenQA.Selenium;

namespace AutomationExercise.Tests.Pages
{
    public class HomePage : BasePage
    {

        private const string Url = "https://automationexercise.com/";
        private readonly By logo = By.CssSelector("img[alt='Website for automation practice']");
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
    }
}
