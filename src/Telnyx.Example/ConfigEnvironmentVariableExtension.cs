using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telnyx.Example
{
    public static class  ConfigEnvironmentVariableExtension
    {
        public static IConfiguration LoadAppSettingsIntoEnvironmentVariables(this IConfiguration config)
        {
            var configAsEnumerable = config.AsEnumerable();
            foreach (var item in configAsEnumerable)
            {
                if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(item.Key)))
                {
                    Environment.SetEnvironmentVariable(item.Key, item.Value);
                }
            }
            return config;
        }
    }
}
