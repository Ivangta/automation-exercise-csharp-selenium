using AutomationExercise.Tests.Base;
using AutomationExercise.Tests.Pages;
using AutomationExercise.Tests.TestData;
using NUnit.Framework;

namespace AutomationExercise.Tests.Tests.UI
{
    public class LoginSignupTests : BaseTest
    {

        [Test]
        public void Signup_Successful()
        {
            //Arrange
            CookieBanner cookieBanner = new CookieBanner(driver!);
            LoginSignupPage loginSignupPage = new LoginSignupPage(driver!);

            //Act
            loginSignupPage.Open();
            cookieBanner.AcceptCookies();
            loginSignupPage.Signup(LoginSignupTestData.ValidName, LoginSignupTestData.ValidEmail);

            //Assert
            string actualErrorMessage = loginSignupPage.GetLoginErrorMessage();
            Assert.That(actualErrorMessage, Is.EqualTo("Your email or password is incorrect!"));
        }


        [Test]
        public void Login_Should_Display_Error_Message_For_Invalid_Credentials()
        {
            //Arrange
            CookieBanner cookieBanner = new CookieBanner(driver!);
            LoginSignupPage loginPage = new LoginSignupPage(driver!);

            //Act
            loginPage.Open();
            cookieBanner.AcceptCookies();
            loginPage.Login(LoginSignupTestData.InvalidEmail, LoginSignupTestData.InvalidPassword);

            //Assert
            string actualErrorMessage = loginPage.GetLoginErrorMessage();
            Assert.That(actualErrorMessage, Is.EqualTo("Your email or password is incorrect!"));
        }


    }
}
