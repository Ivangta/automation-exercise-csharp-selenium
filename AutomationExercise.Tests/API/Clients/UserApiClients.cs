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

        public async Task<ApiResponseModel> CreateUserAsync(
            string name,
            string email)
        {
            var user = new UserRequestModel
            {
                Name = name,
                Email = email,
                Password = "Test123!",
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
    }
}
