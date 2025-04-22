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
            book_info.Text = $"{book.Title} \n {book.Genre} \n {book.Price} \n {book.Pages} \n {book.Author} {book.Description}";

        }
       
    }
}
