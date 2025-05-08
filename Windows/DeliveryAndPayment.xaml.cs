using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ksiegarnia.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy DeliveryAndPayment.xaml
    /// </summary>
    public partial class DeliveryAndPayment : Window
    {
        public DeliveryAndPayment()
        {
            InitializeComponent();
            int customerId = 1; // ID klienta

            // Pobierz klienta wraz z jego adresem
            var customer = BookstoreContex.context.Customers
                  .Include(c => c.Address)
                  .FirstOrDefault(c => c.ID == customerId);

            txtAllCost.Text = $"Razem: {ShoppingCart.TotalPrice()+10} zł";
            txtPurchaseAmount.Text = $"Koszt produktów: {ShoppingCart.TotalPrice()} zł";
            if (customer == null || customer.Address == null)
            {
                txtNoData.Visibility = Visibility.Visible;
            }

            if (customer != null && customer.Address != null)
            {
                txtRecipientName.Text = $"Imię i nazwisko: {customer.Name} {customer.Surname}";
                txtRecipientPhone.Text = $"Numer telefonu: {customer.PhoneNumber}";
                txtRecipientAddress.Text = $"Ulica: {customer.Address.Street}\nNumer domu: {customer.Address.HomeNumber}\nNumer mieszkania: {customer.Address.ApartmentNumber}";
                txtNoData.Visibility = Visibility.Hidden;
            }
        }

        private void EditShippingData(object sender, RoutedEventArgs e)
        {
            UserPanel userPanel = new(this);

            userPanel.Show();
            Close();
        }

    }
}
