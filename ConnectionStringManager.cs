using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ksiegarnia
{
    public static class ConnectionStringManager
    {
        public static string username;
        public static bool isAdmin;
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

            // Rozbij connection string na fragmenty i pobierz wartość "Username"
            var parameters = connectionString.Split(';');
            username = parameters.FirstOrDefault(p => p.StartsWith("Username="))?.Split('=')[1];
            return optionsBuilder.Options;
        }
        // Nowa funkcja do dynamicznej zmiany kontekstu
        public static void ReloadDatabaseContext()
        {
            isAdmin = !isAdmin;
            var options = ContextOptions(); // Pobiera aktualne połączenie z pliku
            BookstoreContex.context = new BookstoreContex(options); // Zmieniamy kontekst na nowy
        }
        public static void ChangeUserNameNotification(Button userButton)
        {
            switch (username)
            {
                case "postgres": userButton.Content = "Witaj, Admin"; break;
                case "jan": userButton.Content = "Witaj, Jan"; break;
                case "admin_user": userButton.Content = "Witaj, Admin"; break;
            }
        }
    }
}
