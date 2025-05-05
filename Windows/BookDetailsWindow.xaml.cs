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
using Ksiegarnia.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace Ksiegarnia
{
    /// <summary>
    /// Logika interakcji dla klasy BookDetailsWindow.xaml
    /// </summary>
    public partial class BookDetailsWindow : Window
    {
        Book book = new Book();
        public BookDetailsWindow(Book book)
        {
            InitializeComponent();
            itemsInCartCounter.Content = ShoppingCart.itemsCounter.ToString();
            this.book = book;
            book_title.Text = book.Title;
            book_author.Text = book.Author.FullName;
            book_price.Text = $"{book.Price} zł";
            book_tag.Text =$"Gatunek: {book.Genre}";
            book_description.Text = book.Description;
            book_pages.Text =$"Liczba stron: {book.Pages.ToString()}";

            if (!string.IsNullOrEmpty(book.CoverPath))
            {
                BookCover.Source = new BitmapImage(new Uri(book.CoverPath));
            }

        }

        private void add_to_card_button_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart.itemsCounter++;
            ShoppingCart.books.Add(book);
            MessageBox.Show($"Dodano {book.Title} do koszyka");
            ShoppingCart.AddBookToCart(itemsInCartCounter);

        }

        private void itemsInCartCounter_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart.ChangeWindowToCart();
        }
        private void UserButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackToSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
