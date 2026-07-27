using AutomationExercise.Tests.API.Models;
using AutomationExercise.Tests.API.Clients;
using NUnit.Framework;
using System.Net;
using System.Text.Json;
using AutomationExercise.Tests.Helpers;

namespace AutomationExercise.Tests.Tests.API
{
    [TestFixture]
    public class UserApiTests
    {
        [Test]
        public async Task CreateUser_Should_Create_New_User_Positive()
        {
            // Arrange
            var userApiClient = new UserApiClients();

            string expectedName = "John " + RandomDataGenerator.GenerateRandomString(10);
            string expectedEmail = $"ivan.{Guid.NewGuid()}@example.com";
            string password = $"123.{Guid.NewGuid()}!";

            // Act
            var createResponse = await userApiClient.CreateUserAsync(expectedName, expectedEmail, password);

            var getUserResponse = await userApiClient.GetUserByEmailAsync(expectedEmail);

            // Assert - create
            Assert.That(createResponse.ResponseCode, Is.EqualTo(201));

            Assert.That(createResponse.Message, Is.EqualTo("User created!"));

            // Assert - get
            Assert.That(getUserResponse.ResponseCode, Is.EqualTo(200));

            Assert.That(getUserResponse.User.Name, Is.EqualTo(expectedName));

            Assert.That(getUserResponse.User.Email, Is.EqualTo(expectedEmail));
        }

        [Test]
        public async Task DeleteUser_Should_Remove_User_Positive()
        {
            // Arrange
            var userApiClient = new UserApiClients();

            string name = "John " + RandomDataGenerator.GenerateRandomString(10);
            string email =
                $"ivan.{Guid.NewGuid()}@example.com";
            string password = "Test123!";

            // Act - create
            var createResponse = await userApiClient.CreateUserAsync(name,  email, password);

            // Act - delete
            var deleteResponse = await userApiClient.DeleteUserAsync(email, password);

            // Assert - create
            Assert.That(createResponse.ResponseCode, Is.EqualTo(201));

            Assert.That(createResponse.Message, Is.EqualTo("User created!"));

            // Assert - delete
            Assert.That(deleteResponse.ResponseCode,Is.EqualTo(200));

            Assert.That(deleteResponse.Message,Is.EqualTo("Account deleted!"));
        }

        [Test]
        public async Task UpdateUser_Should_Update_User_And_Return_Updated_Details()
        {
            // Arrange
            var userApiClient = new UserApiClients();

            string originalName = "John " + RandomDataGenerator.GenerateRandomString(10);
            string updatedName = "Peter " + RandomDataGenerator.GenerateRandomString(10);
            string email = $"ivan.{Guid.NewGuid()}@example.com";
            string password = "Test123!";

            // Act - create
            var createResponse = await userApiClient.CreateUserAsync(originalName, email, password);

            // Act - update
            var updateResponse = await userApiClient.UpdateUserAsync(updatedName, email, password);

            // Act - get updated user
            var getUserResponse = await userApiClient.GetUserByEmailAsync(email);

            // Assert - create
            Assert.That(createResponse.ResponseCode, Is.EqualTo(201));
            Assert.That(createResponse.Message, Is.EqualTo("User created!"));

            // Assert - update
            Assert.That(updateResponse.ResponseCode, Is.EqualTo(200));
            Assert.That(updateResponse.Message, Is.EqualTo("User updated!"));

            // Assert - get
            Assert.That(getUserResponse.ResponseCode, Is.EqualTo(200));
            Assert.That(getUserResponse.User.Name, Is.EqualTo(updatedName));
            Assert.That(getUserResponse.User.Email, Is.EqualTo(email));
        }
    }
}
