using System;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer.Domain.SeedWork
{
    public class BearerTokenOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpiryInMinutes { get; set; }

        public string AuthKey { get; set; }
    }
}
