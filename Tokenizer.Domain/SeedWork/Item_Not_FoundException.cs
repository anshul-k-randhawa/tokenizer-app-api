using System;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer.Domain.SeedWork
{
    public class Item_Not_FoundException : Exception
    {
        public Item_Not_FoundException(string errorDetail) : base(errorDetail) { }
    }
}
