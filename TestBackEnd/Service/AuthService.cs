using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestBackEnd.Helper;
using TestBackEnd.Model;
using TestBackEnd.Request;
using TestBackEnd.Response;
using TestBackEnd.Service.Interface;
using TestBackEnd.Settings;

namespace TestBackEnd.Service
{
    public class AuthService : IAuthService
    {
        public AuthGenearePasswordResponse GeneratePassword()
        {
            var authGenearePasswordResponse = new AuthGenearePasswordResponse();
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@#$%¨&*()!";
            var trying = 0;
            while (trying <= 20)
            {
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (res.Length < 15)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }
                if (ValidatorPassword.IsValid(res.ToString()))
                {
                    authGenearePasswordResponse.Password = res.ToString();
                    break;
                }
                trying++;
            }
            return authGenearePasswordResponse;
        }

        public AuthResponse Login(UserRequest user)
        {
            var authResponse = new AuthResponse(user.User);
            if (user.User == "Leo" && user.Password == "132@Aabd#@!vn_7")
            {
                GenerateToken(authResponse);
            }
            return authResponse;
        }

        public AuthValidadeResponse ValidadePassword(string password)
        {
            var authValidadeResponse = new AuthValidadeResponse();
            authValidadeResponse.Valid = ValidatorPassword.IsValid(password);
            return authValidadeResponse;
        }

        public void GenerateToken(AuthResponse auth)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret.Key);
            var expires = DateTime.UtcNow.AddMinutes(5);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, auth.User.ToString()),
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            auth.Expires = expires;
            auth.Token = tokenHandler.WriteToken(token);
            auth.Authentication = true;

        }
    }
}
