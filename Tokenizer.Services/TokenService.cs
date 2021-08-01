using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer.Domain.Models;
using Tokenizer.Infra.Repositories;

namespace Tokenizer.Services
{
    public class TokenService : ITokenService
    {
        private TokenRepository _tokenRepository;
        private readonly Random random = new Random();
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public TokenService(TokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public async Task<Token> AddToken()
        {
            var length = random.Next(6, 12);
            var tkn = RandomString(length);
            return await _tokenRepository.AddEntity(new Token() { Key = tkn, Validity = DateTime.Now.AddDays(7) });
        }

        public async Task<Token> UpdateToken(string key, bool valid)
        {
            return await _tokenRepository.UpdateEntity(key, valid);
        }

        public async Task<bool> ValidateToken(string key)
        {
            return await _tokenRepository.ValidateEntity(key);
        }

        public async Task<List<Token>> GetTokens(int start, int end)
        {
            return await _tokenRepository.GetListOfEntity(start, end);
        }
    }
}
