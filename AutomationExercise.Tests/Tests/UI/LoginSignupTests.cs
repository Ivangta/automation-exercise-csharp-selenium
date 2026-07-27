using AutomationExercise.Tests.Base;
using AutomationExercise.Tests.Helpers;
using AutomationExercise.Tests.Pages;
using AutomationExercise.Tests.TestData;
using NUnit.Framework;

namespace AutomationExercise.Tests.Tests.UI
{
    public class LoginSignupTests : BaseTest
    {
        [Test]
        public void Signup_User_Registration_Successful_Positive()
        {
            // Arrange
            var loginSignupPage = new LoginSignupPage(driver);
            var accountInformationPage = new AccountInformationPage(driver);
            var accountCreatedPage = new AccountCreatedPage(driver);
            var homePage = new HomePage(driver);
            var cookieBanner = new CookieBanner(driver);

            string firstName = "John";
            string lastName = RandomDataGenerator.GenerateRandomString(10);
            string name = $"{firstName} {lastName}";
            string email = $"john.{Guid.NewGuid()}@example.com";
            string password = "Test123!";

            // Act
            loginSignupPage.Open();
            cookieBanner.AcceptCookies();
            loginSignupPage.Signup(name, email);

            // Assert
            Assert.That(accountInformationPage.IsPageOpened(), Is.True);

            // Act
            accountInformationPage.FillAccountInformation(
                password,
                "10",
                "5",
                "1990",
                firstName,
                lastName,
                "Test Address 1",
                "Canada",
                "Test State",
                "Test City",
                "1000",
                "0888123456");

            accountInformationPage.CreateAccount();

            // Assert
            Assert.That(accountCreatedPage.GetAccountCreatedMessage(), Is.EqualTo("ACCOUNT CREATED!"));

            // Act
            accountCreatedPage.Continue();

            // Assert
            Assert.That(homePage.GetLoggedInAsText(), Is.EqualTo($"Logged in as {name}"));
        }


        [Test]
        public void Login_Should_Display_Error_Message_For_Invalid_Credentials_Negative()
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

        [Test]
        public void User_Should_Not_Register_When_First_Name_Is_Empty()
        {
            // Arrange
            var loginSignupPage = new LoginSignupPage(driver);
            var accountInformationPage = new AccountInformationPage(driver);
            var cookieBanner = new CookieBanner(driver);

            string name = "John " + RandomDataGenerator.GenerateRandomString(10);
            string email = $"john.{Guid.NewGuid()}@example.com";
            string password = "Test123!";

            // Act
            loginSignupPage.Open();
            cookieBanner.AcceptCookies();
            loginSignupPage.Signup(name, email);

            Assert.That(accountInformationPage.IsPageOpened(), Is.True);

            accountInformationPage.FillAccountInformation(
                password,
                "10",
                "5",
                "1990",
                "",                 // First name is left empty on purpose to check the error is correct
                "Smith",
                "Test Address 1",
                "Canada",
                "Test State",
                "Test City",
                "1000",
                "0888123456");

            accountInformationPage.CreateAccount();

            // Assert
            string validationMessage = accountInformationPage.GetFirstNameValidationMessage();

            Assert.That(validationMessage, Is.Not.Empty);
            Assert.That(accountInformationPage.IsPageOpened(), Is.True);
        }
    }
}
