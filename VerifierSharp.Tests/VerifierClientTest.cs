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
            VerifierClient client = new VerifierClient(string.Empty);
            VerifierResponse response = client.VerifyEmailAddressAsync("test@gmail.com").Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, true);
            Assert.AreEqual(response.Email, "test@gmail.com");
            Assert.AreEqual(response.Domain, "gmail.com");
            Assert.IsNull(response.Error);
        }

        // This test requires an API key to run
        [Ignore]
        [TestMethod]
        public void TestBadEmail_ReturnsError()
        {
            VerifierClient client = new VerifierClient(string.Empty);
            VerifierResponse response = client.VerifyEmailAddressAsync("test@gmai.com").Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, false);
            Assert.IsNull(response.Email);
            Assert.IsNull(response.Domain);
            Assert.AreEqual(response.Error.Code, 2);
            Assert.AreEqual(response.Error.Message, "Disposable email address");
        }

        [TestMethod]
        public void TestWrongApiKey_ReturnsError()
        {
            VerifierClient client = new VerifierClient("api_key");
            VerifierResponse response = client.VerifyEmailAddressAsync("test@gmail.com").Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, false);
            Assert.IsNull(response.Email);
            Assert.IsNull(response.Domain);
            Assert.AreEqual(response.Error.Code, 403);
            Assert.AreEqual(response.Error.Message, "Unauthorized");
        }

        [TestMethod]
        public void TestNoApiKeyOrEmail_ReturnsError()
        {
            VerifierClient client = new VerifierClient(string.Empty);

            try
            {
                VerifierResponse response = client.VerifyEmailAddressAsync(string.Empty).Result;
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }
    }
}