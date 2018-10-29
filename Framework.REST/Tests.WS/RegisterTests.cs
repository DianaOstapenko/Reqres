using System.Net;
using Framework.REST;
using Framework.REST.RequestData;
using NUnit.Framework;

namespace Tests.WS
{
    [TestFixture]
    public class RegisterTests
    {
        [Test]
        public void VerifySuccessfulRegistration()
        {
            RegisterRequest requestData = new RegisterRequest
            {
                email = "sydney@fife",
                password = "pistol"
            };

            var registerData = REST.Register.Register(requestData);
            var statusCode = registerData.StatusCode;
            Assert.AreEqual(HttpStatusCode.Created, statusCode);

            var responseToken = registerData.Data.Token;
            //Assert.AreEqual("egfvergeg", responseToken);
            Assert.IsNull(registerData.Data.Error);
        }

        [Test]
        public void VerifyUnsuccessfulRegistration()
        {
            RegisterRequest missingPasswordRequestData = new RegisterRequest
            {
                email = "sydney@fife"
            };
            RegisterRequest missingEmailRequestData = new RegisterRequest
            {
                password = "pistol"
            };

            // Verify Registration without Password;
            var registerData = REST.Register.Register(missingPasswordRequestData);
            var statusCode = registerData.StatusCode;
            Assert.AreEqual(HttpStatusCode.BadRequest, statusCode);

            var error = registerData.Data.Error;
            Assert.AreEqual("Missing password", error);

            // Verify Registration without Email;
            registerData = REST.Register.Register(missingEmailRequestData);
            statusCode = registerData.StatusCode;
            Assert.AreEqual(HttpStatusCode.BadRequest, statusCode);

            error = registerData.Data.Error;
            Assert.AreEqual("Missing email or username", error);
        }
    }
}