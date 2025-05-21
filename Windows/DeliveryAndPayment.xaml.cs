using Ksiegarnia.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace Ksiegarnia.Windows
{
    public partial class DeliveryAndPayment : Window
    {
        public DeliveryAndPayment()
        {
            InitializeComponent();
            int customerId = 1;

            var customer = BookstoreContex.context.Customers
                .Include(c => c.Address)
                .FirstOrDefault(c => c.ID == customerId);

            txtAllCost.Text = $"Razem: {ShoppingCart.TotalPrice() + 10} zł";
            txtPurchaseAmount.Text = $"Koszt produktów: {ShoppingCart.TotalPrice()} zł";

            if (customer == null || customer.Address == null)
            {
                txtNoData.Visibility = Visibility.Visible;
            }
            else
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

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingCart.itemsCounter <= 0)
                return;

            var newOrder = new Orders
            {
                OrderDate = DateTime.Now,
                PirceOrder = ShoppingCart.TotalPrice(),
                CustomerID = 1
            };

            BookstoreContex.context.Orders.Add(newOrder);
            BookstoreContex.context.SaveChanges();

            // Pobieramy książki z bazy danych po ID — to ważne!
            var booksFromDb = ShoppingCart.books
                .Select(b => BookstoreContex.context.Books.FirstOrDefault(dbBook => dbBook.ID == b.ID))
                .Where(b => b != null)
                .ToList();

            foreach (var book in booksFromDb)
            {
                if (book.ID == 0)
                {
                    MessageBox.Show("Błąd – książka nie ma ID");
                    continue;
                }
                var orderBook = new OrdersBooks
                {
                    OrderID = newOrder.ID,
                    BookID = book.ID,
                    Amount = 1,
                    BookPrice = book.Price
                };

                BookstoreContex.context.OrdersBooks.Add(orderBook);
                BookstoreContex.context.Books.Remove(book);
            }

            BookstoreContex.context.SaveChanges();
            ShoppingCart.books.Clear();

            MessageBox.Show("Pomyślnie zakupiono");

            ShoppingCart.itemsCounter = 0;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void backToSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
