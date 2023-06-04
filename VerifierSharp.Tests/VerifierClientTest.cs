using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerifierSharp.Models;

namespace VerifierSharp.Tests
{
    [TestClass]
    public class VerifierClientTest
    {
        // This test requires an API key to run
        [Ignore]
        [TestMethod]
        public void TestValidSettings_ReturnsEmailAndDomain()
        {
            VerifierClient client = new VerifierClient();
            VerifierSettings settings = new VerifierSettings()
            {
                EmailAddress = "test@gmail.com",
                ApiKey = string.Empty
            };

            VerifierResponse response = client.VerifyEmailAddressAsync(settings).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, true);
            Assert.AreEqual(response.Email, "test@gmail.com");
            Assert.AreEqual(response.Domain, "gmail.com");
            Assert.IsNull(response.Error);
        }

        [TestMethod]
        public void TestIncorrectSettings_ReturnsError()
        {
            VerifierClient client = new VerifierClient();
            VerifierSettings settings = new VerifierSettings()
            {
                EmailAddress = "test@gmail.com",
                ApiKey = "api_key"
            };

            VerifierResponse response = client.VerifyEmailAddressAsync(settings).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, false);
            Assert.IsNull(response.Email);
            Assert.IsNull(response.Domain);
            Assert.AreEqual(response.Error.Code, 403);
            Assert.AreEqual(response.Error.Message, "Unauthorized");
        }

        [TestMethod]
        public void TestNoSettings_ReturnsError()
        {
            VerifierClient client = new VerifierClient();

            try
            {
                VerifierResponse response = client.VerifyEmailAddressAsync(null).Result;
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }
    }
}