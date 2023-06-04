using System.Text.Json.Serialization;

namespace VerifierSharp.Models
{
    public class VerifierResponse
    {
        /// <summary>
        /// The result as true/false for the API call
        /// </summary>
        /// <value></value>
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        /// <summary>
        /// The email address that was checked
        /// </summary>
        /// <value></value>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// The domain of the email address that was checked
        /// </summary>
        /// <value></value>
        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// An object holding the error code and message from the API
        /// </summary>
        /// <value></value>
        [JsonPropertyName("error")]
        public VerifierError Error { get; set; }
    }
}
