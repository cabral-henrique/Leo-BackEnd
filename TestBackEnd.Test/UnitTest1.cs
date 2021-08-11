using NUnit.Framework;
using TestBackEnd.Request;
using TestBackEnd.Service;
using TestBackEnd.Service.Interface;

namespace TestBackEnd.Test
{
    public class Tests
    {
        private readonly IAuthService service;
        public Tests()
        {
            service = new AuthService();
        }
        [Test]
        public void Login_OK()
        {
            var result = service.Login(new UserRequest { User = "Leo",  Password = "132@Aabd#@!vn_7" });
            Assert.AreEqual(result.Authentication, true);
        }
        [Test]
        public void Login_Fail()
        {
            var result = service.Login(new UserRequest { User = "Leo", Password = "12345678" });
            Assert.AreEqual(result.Authentication, false);
        }

        [Test]
        public void Validade_Password_OK()
        {
            var result = service.ValidadePassword("132@Aabd#@!vn_7");
            Assert.AreEqual(result.Valid, true) ;
        }

        [Test]
        public void Validade_Password_Fail()
        {
            var result = service.ValidadePassword("111@Aabd#@!vn_7");
            Assert.AreEqual(result.Valid, false);
        }
    }
}