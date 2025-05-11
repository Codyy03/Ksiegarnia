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
using Ksiegarnia.Windows;
using static System.Reflection.Metadata.BlobBuilder;

namespace Ksiegarnia
{
    /// <summary>
    /// Logika interakcji dla klasy BookDetailsWindow.xaml
    /// </summary>
    public partial class BookDetailsWindow : Window
    {
        Book book = new Book();

        public BookDetailsWindow(Book book, List<GroupedBookViewModel> groupedBooks)
        {
            InitializeComponent();
            itemsInCartCounter.Content = ShoppingCart.itemsCounter.ToString();
            this.book = book;
            book_title.Text = book.Title;
            book_author.Text = book.Author.FullName;
            book_price.Text = $"{book.Price} zł";
            book_tag.Text = $"Gatunek: {book.Genre}";
            book_description.Text = book.Description;
            book_pages.Text = $"Liczba stron: {book.Pages.ToString()}";
            biography.Text =$"Krótka biografia autora: {book.Author.Biography}";
            authorsNationality.Text = $"Narodowość autora : {book.Author.Nationality}";

            ConnectionStringManager.ChangeUserNameNotification(UserButton);

            foreach (GroupedBookViewModel item in groupedBooks)
            {

                if (item.Title == book.Title)
                {
                    booksCopies.Text = $"Ilość dostępnych egzempalrzy: {item.Count}";
                    break;
                }
            }
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
            Close();
        }
        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowUserPanel(this);
            mainWindow.Close();
        }

        private void BackToSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }


        private void EditBook_Click_1(object sender, RoutedEventArgs e)
        {
            BookEditWindow bookEditWindow = new BookEditWindow(book);
            bookEditWindow.Show();
            Close();
        }
    }
}
