using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Ksiegarnia.Entities;
using Ksiegarnia.Windows;

namespace Ksiegarnia
{
    /// <summary>
    /// Logika interakcji dla klasy ShoopingCartWindow.xaml
    /// </summary>
    public partial class ShoopingCartWindow : Window
    {
        public ShoopingCartWindow()
        {
            InitializeComponent();

            BooksInShoopingCart.ItemsSource = ShoppingCart.books;


            AllBooksPrice();

        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                Book book = (Book)button.DataContext;
                ShoppingCart.books.Remove(book);
                ShoppingCart.itemsCounter--;
                AllBooksPrice();
            }
        }
        private void AllBooksPrice() {
            TotalPrice.Text = $"Kwota końcowa: {ShoppingCart.TotalPrice().ToString()} zł";
        }

        private void ShoppingSummary_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingCart.itemsCounter == 0)
                return;

            DeliveryAndPayment deliveryAndPayment = new();

            deliveryAndPayment.Show();
            Close();

        }
        private void BackToSearch_Click(object sender, RoutedEventArgs e)
        { 
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            Close();
        
        }

    }
}
