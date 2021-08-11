using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBackEnd.Response
{
    public class AuthResponse
    {
        public AuthResponse(string user)
        {
            User = user;
        }
        public string User { get; set; }
        public bool Authentication { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
