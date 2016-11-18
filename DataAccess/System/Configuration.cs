using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace  DataAcess
{
    internal static class Configuration
    {
        const string DEFAULT_CONNECTION_KEY = "projectConnection";

        public static string DefaultConnection
        {
            get
            {
                return ConfigurationManager.AppSettings[DEFAULT_CONNECTION_KEY];
            }
        }

        public static string DBProvider
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DEFAULT_CONNECTION_KEY].ProviderName;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DEFAULT_CONNECTION_KEY].ConnectionString;
            }
        }

    }
}
