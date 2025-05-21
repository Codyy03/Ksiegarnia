using Ksiegarnia.Entities;
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
    /// Logika interakcji dla klasy BookEditWindow.xaml
    /// </summary>
    public partial class BookEditWindow : Window
    {
        readonly Book book;
        public BookEditWindow(Book book)
        {
            InitializeComponent();
            this.book = book;
            book_descriptionTextBox.Text = book.Description;
            book_titleTextBox.Text = book.Title;
            book_tagTextBox.Text = book.Genre;
            book_pagesTextBox.Text = book.Pages.ToString();
            book_priceTextBox.Text = book.Price.ToString();
            book_languageTextBox.Text = book.Language;
        }
        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            ShowUserPanel(this);
        }
        private void itemsInCartCounter_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart.ChangeWindowToCart();
            Close();
        }
        public void ShowUserPanel(Window window)
        {
            UserPanel userPanel = new UserPanel(this);
            userPanel.Show();
            window.Close();
        }
        private void BackToSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void updateBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (book == null)
                    return;

                book.Title = book_titleTextBox.Text;
                book.Description = book_descriptionTextBox.Text;
                if (decimal.TryParse(book_priceTextBox.Text.Replace("zł", "").Trim(), out decimal newPrice))
                {
                    book.Price = newPrice;
                }
                book.Language = book_languageTextBox.Text;

                if (int.TryParse(book_pagesTextBox.Text, out int pageCount) && pageCount > 0)
                {
                    book.Pages = Convert.ToInt32(book_pagesTextBox.Text);
                }
                book.Genre = book_tagTextBox.Text;

                if (string.IsNullOrEmpty(book_titleTextBox.Text) || string.IsNullOrEmpty(book_descriptionTextBox.Text) || string.IsNullOrEmpty(book_priceTextBox.Text) || string.IsNullOrEmpty(book_languageTextBox.Text) || string.IsNullOrEmpty(book_pagesTextBox.Text) || string.IsNullOrEmpty(book_pagesTextBox.Text) || string.IsNullOrEmpty(book_tagTextBox.Text))
                {
                    MessageBox.Show("Nieprawidłowe dane");
                    return;
                }

                MessageBox.Show("Poprawinie edytowano");
                BookstoreContex.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas aktualizacji danych: {ex.Message}");
            }
        }


    }
}
