using Core.Entities.Concrete;
using Core.Utilities.Secrity2.Encyption;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Secrity2.Jwt
{
    public class JwtTokenHelper : ITokenHelper
    {
        private IConfiguration _configuration;
        private DateTime _accessTokenExpiration;
        private TokenOptions _tokenOptions;
        public JwtTokenHelper(IConfiguration configuration, DateTime _accessTokenExpiration)
        {
            _configuration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

        }
        public AccessToken CreateToken(User user, List<OperationClaim> claims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signinCredential = SigninCredentialHelper.CreateSigningCredentials(securityKey);

        }

    }
}
