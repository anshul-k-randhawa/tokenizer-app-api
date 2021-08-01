using System;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer.Domain.Models
{
    public class Token : IEntity
    {
        public string Key { get; set; }
        public DateTime Validity { get; set; }
    }
}
