using Microsoft.EntityFrameworkCore;
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
    public static class ConnectionStringManager
    {
        
        public static DbContextOptions<BookstoreContex> ContextOptions()
        {
            string path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName);
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configurationBuilder.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string 'DefaultConnection' is null or empty.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<BookstoreContex>();
            optionsBuilder.UseNpgsql(connectionString); // Konfiguracja połączenia do PostgreSQL
            return optionsBuilder.Options;
        }
    }
}
