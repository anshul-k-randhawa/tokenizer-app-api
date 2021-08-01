using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer.Domain.Models;

namespace Tokenizer.Infra.Repositories
{
    public class TokenRepository : MemoryRepository<Token>, ITokenRepository
    {
        public override Task<Token> AddEntity(Token item)
        {
            return base.AddEntity(item);
        }

        public override Task<Token> UpdateEntity(string key, bool valid)
        {
            return base.UpdateEntity(key, valid);
        }

        public Task<bool> ValidateEntity(string key)
        {
            var tokens = base.GetListOfEntity(-1, -1).Result;
            var result = Task.Run<bool>(() => tokens.Count > 0 && tokens.Any(i => i.Key.Equals(key) && i.Validity > DateTime.Now));

            return result;
        }

        public override Task<List<Token>> GetListOfEntity(int start, int end)
        {
            return base.GetListOfEntity(start, end);
        }
    }
}
