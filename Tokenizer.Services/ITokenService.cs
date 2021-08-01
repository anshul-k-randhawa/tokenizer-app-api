using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tokenizer.Domain.Models;

namespace Tokenizer.Services
{
    public interface ITokenService
    {
        Task<bool> ValidateToken(string key);
        Task<Token> UpdateToken(string key, bool valid);
        Task<Token> AddToken();
        Task<List<Token>> GetTokens(int start, int end);
    }
}
