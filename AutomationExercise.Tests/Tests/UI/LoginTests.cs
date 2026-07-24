using AutomationExercise.Tests.Base;
using AutomationExercise.Tests.Pages;
using NUnit.Framework;

namespace AutomationExercise.Tests.Tests.UI
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void Login_Should_Display_Error_Message_For_Invalid_Credentials()
        {
            //Arrange
            CookieBanner cookieBanner = new CookieBanner(driver!);
            LoginPage loginPage = new LoginPage(driver!);

            //Act
            loginPage.Open();
            cookieBanner.AcceptCookies();
            loginPage.Login("invalidEmail@mail.com", "InvalidPassword456!");

            //Assert
            string actualErrorMessage = loginPage.GetLoginErrorMessage();
            Assert.That(actualErrorMessage, Is.EqualTo("Your email or password is incorrect!"));
        }
    }
}
