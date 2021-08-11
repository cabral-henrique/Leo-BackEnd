using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBackEnd.Model;
using TestBackEnd.Request;
using TestBackEnd.Response;
using TestBackEnd.Service.Interface;

namespace TestBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;
        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        [HttpPost("login")]

        public AuthResponse Login(UserRequest user)
        {
            return service.Login(user);
        }

        [HttpPost("validPassword")]
        [Authorize]
        public AuthValidadeResponse ValidPassword([FromBody]PasswordRequest passwordRequest)
        {
            return service.ValidadePassword(passwordRequest.Password);
        }

        [HttpGet("generatorPassword")]
        [Authorize]
        public AuthGenearePasswordResponse GeneratorPassword()
        {
            return service.GeneratePassword();
        }
    }
}
