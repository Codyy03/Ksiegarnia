using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
namespace Ksiegarnia
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName);
            // Użycie pełnej przestrzeni nazw dla Microsoft.Extensions.Configuration
            var configurationManager = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(path) // Lub Directory.GetCurrentDirectory()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configurationManager.GetConnectionString("DefaultConnection");

            using (var context = new BookstoreContex(connectionString))
            {
                // Przykładowe operacje, np. sprawdzenie połączenia
                context.Database.EnsureCreated();
            }
        }
        protected override void OnExit(ExitEventArgs e)
        {
            ShoppingCart.SaveCartToJson();
            base.OnExit(e);
        }
    }
}
