using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tokenizer.Domain.Models;

namespace Tokenizer.Infra.Repositories
{
    interface ITokenRepository : IRepository<Token>
    {
        Task<bool> ValidateEntity(string key);
    }
}
