using System.Text.Json.Serialization;

namespace VerifierSharp.Models
{
    public class VerifierError
    {
        /// <summary>
        /// The HTTP status code as a number
        /// </summary>
        /// <value></value>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// The error message from the API
        /// </summary>
        /// <value></value>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
