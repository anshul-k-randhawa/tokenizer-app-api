using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokenizer.Api.Helpers
{
    public static class AppSettingsHelper
    {
        public static T RetrieveSection<T>(IConfiguration configuration, string sectionName)
        {
            T type = configuration.GetSection(sectionName).Get<T>();

            return type;
        }
    }
}
