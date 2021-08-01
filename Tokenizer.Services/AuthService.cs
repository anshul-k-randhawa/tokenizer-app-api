using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Services
{
    public class AuthService : IAuthService
    {
        public async Task<bool> ValidateCreds(string login, string passwd)
        {
            return await Task.FromResult<bool>(login.Equals("test@email.com") && passwd.Equals("p@ssword"));
        }
    }
}
