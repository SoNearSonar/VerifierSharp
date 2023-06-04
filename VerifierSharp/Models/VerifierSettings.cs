namespace VerifierSharp.Models
{
    public class VerifierSettings
    {
        /// <summary>
        /// The token for using this API
        /// </summary>
        /// <value></value>
        public string ApiKey { get; set; }

        /// <summary>
        /// The email address to check
        /// </summary>
        /// <value></value>
        public string EmailAddress { get; set; }
    }
}
