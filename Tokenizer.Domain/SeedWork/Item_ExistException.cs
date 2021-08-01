using System;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer.Domain.SeedWork
{
    public class Item_ExistException : Exception
    {
        public Item_ExistException(string errorDetail) : base(errorDetail) { }
    }
}
