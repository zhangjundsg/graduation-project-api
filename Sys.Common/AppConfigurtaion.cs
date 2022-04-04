using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Sys.Common
{
    public class AppConfigurtaion
    {
        public static string GetConfigStr(string key) 
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return config[key];
        }
        public static string GetConfigObj(string key)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return config.GetSection(key).Value;
        }
    }
}
