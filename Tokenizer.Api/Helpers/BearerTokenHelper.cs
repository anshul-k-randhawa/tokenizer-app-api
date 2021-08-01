using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Api.Helpers
{
    public class BearerTokenHelper
    {
        private string _issuer;
        private string _audience;
        private DateTime _expires;
        private SigningCredentials _credentials;
        private SymmetricSecurityKey _key;
        private List<Claim> _claims;

        public BearerTokenHelper AddClaims(List<Claim> claims)
        {
            if (_claims == null)
                _claims = claims;
            else
                _claims.AddRange(claims);

            return this;
        }

        public BearerTokenHelper AddClaim(Claim claim)
        {
            if (_claims == null)
                _claims = new List<Claim>() { claim };
            else
                _claims.Add(claim);

            return this;
        }

        public BearerTokenHelper AddIssuer(string issuer)
        {
            _issuer = issuer;
            return this;
        }

        public BearerTokenHelper AddAudience(string audience)
        {
            _audience = audience;
            return this;
        }

        public BearerTokenHelper AddExpiry(int minutes)
        {
            _expires = DateTime.Now.AddMinutes(minutes);
            return this;
        }

        public BearerTokenHelper AddKey(string key)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            _credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            return this;
        }

        public JwtSecurityToken Build()
        {
            return new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: _claims,
                expires: _expires,
                signingCredentials: _credentials
            );
        }
    }
}
