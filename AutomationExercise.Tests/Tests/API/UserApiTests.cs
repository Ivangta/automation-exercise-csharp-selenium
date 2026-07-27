using AutomationExercise.Tests.API.Models;
using AutomationExercise.Tests.API.Clients;
using NUnit.Framework;
using System.Net;
using System.Text.Json;

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

            string name = "Ivan";
            string email = $"ivan.{Guid.NewGuid()}@example.com";

            // Act
            var createResponse =
                await userApiClient.CreateUserAsync(name, email);

            // Assert
            Assert.That(createResponse.ResponseCode, Is.EqualTo(201));
            Assert.That(createResponse.Message, Is.EqualTo("User created!"));
        }
    }
}
