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

namespace Ksiegarnia
{
    /// <summary>
    /// Logika interakcji dla klasy ShoopingCartWindow.xaml
    /// </summary>
    public partial class ShoopingCartWindow : Window
    {
        decimal totalPrice = 0;
        public ShoopingCartWindow()
        {
            InitializeComponent();

            BooksInShoopingCart.ItemsSource = ShoppingCart.books;

            foreach (Book book in ShoppingCart.books)
                totalPrice += book.Price;

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
                totalPrice -= book.Price;
                AllBooksPrice();
            }
        }
        private void AllBooksPrice() {
            TotalPrice.Text = $"Kwota końcowa: {totalPrice.ToString()} zł";
        } 
    }
}
