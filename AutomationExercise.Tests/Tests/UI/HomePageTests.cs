using AutomationExercise.Tests.Base;
using AutomationExercise.Tests.Pages;
using NUnit.Framework;

namespace AutomationExercise.Tests.Tests.UI
{
    public class HomePageTests : BaseTest
    {
        [Test]
        public void HomePage_Should_Display_Logo()
        {
            HomePage homePage = new HomePage(driver!);

            homePage.Open();

            bool isDisplayed = homePage.IsLogoDisplayed();

            Assert.That(isDisplayed, Is.True);
        }
    }
}
