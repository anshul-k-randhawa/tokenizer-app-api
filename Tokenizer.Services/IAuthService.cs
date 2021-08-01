using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateCreds(string login, string passwd);
    }
}
