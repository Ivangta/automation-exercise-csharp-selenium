using AutomationExercise.Tests.Helpers;

namespace AutomationExercise.Tests.TestData
{
    public static class LoginSignupTestData
    {
        public const string InvalidEmail = "invalidEmail@mail.com";

        public const string InvalidPassword = "InvalidPassword456!";

        public static readonly string ValidName = RandomDataGenerator.GenerateRandomString(6);

        public static readonly string ValidEmail = $"{RandomDataGenerator.GenerateRandomString(10)}@gmail.com";


    }
}
