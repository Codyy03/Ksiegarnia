using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Shapes;
using System.IO;
namespace Ksiegarnia.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        public UserPanel(Window window)
        {
            InitializeComponent();
            LoadUserData();

        }
        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            int customerId = 1; // ID klienta

            // Pobierz klienta wraz z jego adresem
            var customer = BookstoreContex.context.Customers
                  .Include(c => c.Address)
                  .FirstOrDefault(c => c.ID == customerId);

            customer.Name = txtName.Text;
            customer.Surname = txtSurname.Text;
            customer.Email = txtEmail.Text;
            customer.PhoneNumber = txtPhoneNumber.Text;


            if (customer?.Address != null)
            {
                customer.Address.City = txtCity.Text;
                customer.Address.Street = txtStreet.Text;
                txtApartmentNumber.Text = customer.Address.ApartmentNumber;
                customer.Address.HomeNumber = txtHomeNumber.Text;
                customer.Address.ZipCode = txtZipCode.Text;
            }

            BookstoreContex.context.SaveChanges();
            CloseWindows();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CloseWindows();
        }
        void CloseWindows()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void LoadUserData()
        {
            int customerId = 1; // ID klienta

            // Pobierz klienta wraz z jego adresem
            var customer = BookstoreContex.context.Customers
                  .Include(c => c.Address)
                  .FirstOrDefault(c => c.ID == customerId);

            txtName.Text = customer.Name;
            txtSurname.Text = customer.Surname;
            txtEmail.Text = customer.Email;
            txtPhoneNumber.Text = customer.PhoneNumber;


            if (customer?.Address != null)
            {
                txtCity.Text = customer.Address.City;
                txtStreet.Text = customer.Address.Street;
                txtApartmentNumber.Text = customer.Address.ApartmentNumber;
                txtHomeNumber.Text = customer.Address.HomeNumber;
                txtZipCode.Text = customer.Address.ZipCode;
            }

        }

        private void userHistoryButon_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.Show();
            Close();
        }

        private void changeUserToAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Przeładowujemy kontekst na nowe połączenie
                ConnectionStringManager.ReloadDatabaseContext();
               
                // Sprawdzamy, czy możemy wykonać zapytanie (czy połączenie działa)
               
                    if (BookstoreContex.context.Database.CanConnect()) // Sprawdzenie czy połączenie jest możliwe
                    {
                        MessageBox.Show("Połączenie z bazą zostało odświeżone. Nowe dane użytkownika są aktywne.");
                    }
                    else
                    {
                        MessageBox.Show("Błąd: Nie udało się połączyć z bazą. Sprawdź dane użytkownika w pliku konfiguracyjnym.", "Błąd połączenia", MessageBoxButton.OK, MessageBoxImage.Error);
                        ResetConfigurationToDefault();
                        // Przeładowujemy kontekst na nowe połączenie
                        ConnectionStringManager.ReloadDatabaseContext();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się połączyć z bazą. Sprawdź poprawność danych użytkownika w pliku konfiguracyjnym.\n\nSzczegóły: {ex.Message}",
                                "Błąd połączenia", MessageBoxButton.OK, MessageBoxImage.Error);
                ResetConfigurationToDefault();
                // Przeładowujemy kontekst na nowe połączenie
                ConnectionStringManager.ReloadDatabaseContext();
            }
        }
        private void ResetConfigurationToDefault()
        {
            // Domyślna zawartość pliku konfiguracyjnego
            string defaultJson = @"{
              ""ConnectionStrings"": {
                ""DefaultConnection"": ""Host=127.0.0.1;Port=5433;Database=Ksiegarnia;Username=postgres;Password=admin""
              }
            }";

            string path = System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "appsettings.json");

            // Zapisujemy domyślną konfigurację do pliku
            File.WriteAllText(path, defaultJson);
        }

    }
}
