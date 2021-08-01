using System;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer.Domain.Models
{
    public interface IEntity
    {
        string Key { get; set; }
        DateTime Validity { get; set; }
    }
}
