using System.Text.Json.Serialization;

namespace AutomationExercise.Tests.API.Models
{
    public class ApiResponseModel
    {
        [JsonPropertyName("responseCode")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}
