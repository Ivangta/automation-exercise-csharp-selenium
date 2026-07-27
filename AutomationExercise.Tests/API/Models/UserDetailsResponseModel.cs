using System.Text.Json.Serialization;

namespace AutomationExercise.Tests.API.Models
{
    public class UserDetailsResponseModel
    {
        [JsonPropertyName("responseCode")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("user")]
        public UserDetailsModel User { get; set; } = new();
    }

    public class UserDetailsModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
    }
}
