using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Secrity2.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
