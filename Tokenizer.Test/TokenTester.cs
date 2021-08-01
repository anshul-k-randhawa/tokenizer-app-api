using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tokenizer.Infra.Repositories;
using Tokenizer.Services;

namespace Tokenizer.Test
{
    [TestClass]
    public class TokenTester
    {
        [TestMethod]
        public void TestTokenGeneration()
        {
            var service = new TokenService(new TokenRepository());
            var token = service.AddToken().Result;
            Assert.IsTrue(token.Key.Length >= 6 && token.Key.Length <= 12, "Token length must be between 6 and 12.");
        }

        [TestMethod]
        public void TestTokenValidation()
        {
            var service = new TokenService(new TokenRepository());
            var token = service.AddToken().Result;
            var isValid = service.ValidateToken(token.Key).Result;
            Assert.IsTrue(isValid, "Newly generated token must be valid.");

            token = service.UpdateToken(token.Key, false).Result;
            isValid = service.ValidateToken(token.Key).Result;

            Assert.IsFalse(isValid, "After invalidating, token must be invalid.");
        }
    }
}
