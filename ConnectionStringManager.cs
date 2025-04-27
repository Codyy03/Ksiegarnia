using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    public class ConnectionStringManager
    {
        private IConfigurationRoot configuration;

        public ConnectionStringManager(IConfiguration configuration)
        {
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        }
        public string GetConnectionString(string name)
        {
            return configuration.GetConnectionString(name);
        }
    }
}
