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

namespace Ksiegarnia
{
    /// <summary>
    /// Logika interakcji dla klasy BookDetailsWindow.xaml
    /// </summary>
    public partial class BookDetailsWindow : Window
    {
        public BookDetailsWindow(Book book)
        {
            InitializeComponent();
            book_title.Text = book.Title;
            book_author.Text = book.Author.FullName;
            book_price.Text = $"{book.Price} zł";
            book_tag.Text = book.Genre;
            book_description.Text = book.Description;
            if (!string.IsNullOrEmpty(book.CoverPath))
            {
                BookCover.Source = new BitmapImage(new Uri(book.CoverPath));
            }

        }
       
    }
}
