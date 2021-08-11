using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBackEnd.Model;
using TestBackEnd.Request;
using TestBackEnd.Response;

namespace TestBackEnd.Service.Interface
{
    public interface IAuthService
    {
        AuthResponse Login(UserRequest user);
        AuthValidadeResponse ValidadePassword(string password);
        AuthGenearePasswordResponse GeneratePassword();

    }
}
