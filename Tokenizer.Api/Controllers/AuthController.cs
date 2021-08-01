using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Tokenizer.Api.DTO;
using Tokenizer.Api.Helpers;
using Tokenizer.Domain.SeedWork;
using Tokenizer.Services;

namespace Tokenizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var proceed = await _authService.ValidateCreds(login.email,login.password);
            if (proceed)
            {
                // TODO: Validate accessCode

                List<Claim> claims = new List<Claim>() {
                    new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim (JwtRegisteredClaimNames.Email, "")
                };

                BearerTokenOptions bearerTokenOptions = AppSettingsHelper.RetrieveSection<BearerTokenOptions>(_configuration, "STSBearerToken");

                JwtSecurityToken token = new BearerTokenHelper()
                            .AddAudience(bearerTokenOptions.Audience)
                            .AddIssuer(bearerTokenOptions.Issuer)
                            .AddExpiry(bearerTokenOptions.ExpiryInMinutes)
                            .AddKey(bearerTokenOptions.AuthKey)
                            .AddClaims(claims)
                            .Build();

                
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = tokenString, ExpiresIn = bearerTokenOptions.ExpiryInMinutes });
            }

            return BadRequest("Invalid credentials!!");
        }
    }
}
