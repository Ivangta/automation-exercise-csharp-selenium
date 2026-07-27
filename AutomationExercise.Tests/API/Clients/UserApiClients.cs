using AutomationExercise.Tests.API.Models;
using RestSharp;
using System.Text.Json;

namespace AutomationExercise.Tests.API.Clients
{
    internal class UserApiClients
    {
        private readonly RestClient client;

        public UserApiClients()
        {
            client = new RestClient(
                "https://automationexercise.com");
        }

        public async Task<ApiResponseModel> CreateUserAsync(string name, string email, string password)
        {
            var user = new UserRequestModel
            {
                Name = name,
                Email = email,
                Password = password,
                Title = "Mr",
                BirthDate = "10",
                BirthMonth = "5",
                BirthYear = "1990",
                FirstName = name,
                LastName = "Test",
                Company = "Test Company",
                Address1 = "Test Address 1",
                Address2 = "Test Address 2",
                Country = "Canada",
                ZipCode = "1000",
                State = "Test State",
                City = "Test City",
                MobileNumber = "0888123456"
            };

            var request = new RestRequest(
                "/api/createAccount",
                Method.Post);

            request.AddParameter("name", user.Name);
            request.AddParameter("email", user.Email);
            request.AddParameter("password", user.Password);
            request.AddParameter("title", user.Title);
            request.AddParameter("birth_date", user.BirthDate);
            request.AddParameter("birth_month", user.BirthMonth);
            request.AddParameter("birth_year", user.BirthYear);
            request.AddParameter("firstname", user.FirstName);
            request.AddParameter("lastname", user.LastName);
            request.AddParameter("company", user.Company);
            request.AddParameter("address1", user.Address1);
            request.AddParameter("address2", user.Address2);
            request.AddParameter("country", user.Country);
            request.AddParameter("zipcode", user.ZipCode);
            request.AddParameter("state", user.State);
            request.AddParameter("city", user.City);
            request.AddParameter("mobile_number", user.MobileNumber);

            var response = await client.ExecuteAsync(request);

            var responseModel =
                JsonSerializer.Deserialize<ApiResponseModel>(
                    response.Content!);

            if (responseModel is null)
            {
                throw new InvalidOperationException(
                    "Create user response could not be deserialized.");
            }

            return responseModel;
        }

        public async Task<ApiResponseModel> UpdateUserAsync(string name, string email, string password)
        {
            var user = new UserRequestModel
            {
                Name = name,
                Email = email,
                Password = password,
                Title = "Mr",
                BirthDate = "10",
                BirthMonth = "5",
                BirthYear = "1990",
                FirstName = name,
                LastName = "Test",
                Company = "Test Company",
                Address1 = "Test Address 1",
                Address2 = "Test Address 2",
                Country = "Canada",
                ZipCode = "1000",
                State = "Test State",
                City = "Test City",
                MobileNumber = "0888123456"
            };

            var request = new RestRequest("/api/updateAccount", Method.Put);

            request.AddParameter("name", user.Name);
            request.AddParameter("email", user.Email);
            request.AddParameter("password", user.Password);
            request.AddParameter("title", user.Title);
            request.AddParameter("birth_date", user.BirthDate);
            request.AddParameter("birth_month", user.BirthMonth);
            request.AddParameter("birth_year", user.BirthYear);
            request.AddParameter("firstname", user.FirstName);
            request.AddParameter("lastname", user.LastName);
            request.AddParameter("company", user.Company);
            request.AddParameter("address1", user.Address1);
            request.AddParameter("address2", user.Address2);
            request.AddParameter("country", user.Country);
            request.AddParameter("zipcode", user.ZipCode);
            request.AddParameter("state", user.State);
            request.AddParameter("city", user.City);
            request.AddParameter("mobile_number", user.MobileNumber);

            var response = await client.ExecuteAsync(request);

            if (string.IsNullOrWhiteSpace(response.Content))
            {
                throw new InvalidOperationException("Update user API returned an empty response.");
            }

            var responseModel = JsonSerializer.Deserialize<ApiResponseModel>(response.Content);

            if (responseModel is null)
            {
                throw new InvalidOperationException($"Update response could not be deserialized. Content: {response.Content}");
            }

            return responseModel;
        }

        public async Task<UserDetailsResponseModel> GetUserByEmailAsync(string email)
        {
            var request = new RestRequest(
                "/api/getUserDetailByEmail",
                Method.Get);

            request.AddQueryParameter("email", email);

            var response = await client.ExecuteAsync(request);

            var responseModel =
                JsonSerializer.Deserialize<UserDetailsResponseModel>(
                    response.Content!);

            if (responseModel is null)
            {
                throw new InvalidOperationException(
                    "Get user response could not be deserialized.");
            }

            return responseModel;
        }

        public async Task<ApiResponseModel> DeleteUserAsync(string email, string password)
        {
            var request = new RestRequest("/api/deleteAccount", Method.Delete);

            string requestBody = $"email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}";

            request.AddStringBody(requestBody, ContentType.FormUrlEncoded);

            var response = await client.ExecuteAsync(request);

            Console.WriteLine($"HTTP status: {response.StatusCode}");
            Console.WriteLine($"Content: {response.Content}");

            if (string.IsNullOrWhiteSpace(response.Content))
            {
                throw new InvalidOperationException("Delete user API returned an empty response.");
            }

            var responseModel = JsonSerializer.Deserialize<ApiResponseModel>(response.Content);

            if (responseModel is null)
            {
                throw new InvalidOperationException($"Delete response could not be deserialized. Content: {response.Content}");
            }

            return responseModel;
        }
    }
}
