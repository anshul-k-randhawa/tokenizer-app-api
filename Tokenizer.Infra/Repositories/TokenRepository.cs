using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tokenizer.Domain.Models;

namespace Tokenizer.Infra.Repositories
{
    public class TokenRepository : MemoryRepository<Token>
    {
        public override Task<Token> AddEntity(Token item)
        {
            return base.AddEntity(item);
        }

        public override Task<Token> UpdateEntity(string key, bool valid)
        {
            return base.UpdateEntity(key, valid);
        }

        public override Task<bool> ValidateEntity(string key)
        {
            return base.ValidateEntity(key);
        }

        public override Task<List<Token>> GetListOfEntity(int start, int end)
        {
            return base.GetListOfEntity(start, end);
        }
    }
}
