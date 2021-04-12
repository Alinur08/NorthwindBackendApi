using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Secrity2.Encyption
{
    public class SigninCredentialHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey key)
        {
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }
    }
}
