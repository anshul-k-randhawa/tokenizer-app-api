using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tokenizer.Services;

namespace Tokenizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }


        [Authorize]
        [HttpGet("generate")]
        public async Task<IActionResult> Generate()
        {
            var result = await _tokenService.AddToken();
            return Ok(result);
        }

        [Authorize]
        [HttpPost("update")]
        public async Task<IActionResult> Update(string key, bool valid)
        {
            var result = await _tokenService.UpdateToken(key, valid);
            return Ok(result);
        }


        [HttpGet("validate")]
        public async Task<IActionResult> Validate(string key)
        {
            var result = await _tokenService.ValidateToken(key);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("list")]
        public async Task<IActionResult> Validate(int start,int end)
        {
            var result = await _tokenService.GetTokens(start,end);
            return Ok(result);
        }


    }
}
