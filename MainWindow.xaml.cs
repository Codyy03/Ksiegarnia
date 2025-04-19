using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ksiegarnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> allBooks { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            allBooks = new ObservableCollection<Book>();
            using (BookstoreContex context = new BookstoreContex())
            {
                try
                {
                    var books = context.Books.ToList();
                    foreach (var book in books)
                    {
                        allBooks.Add(book);
                    }
                    BooksList.ItemsSource = allBooks;
                    BooksList.Visibility = allBooks.Count > 0 ? Visibility.Visible : Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
            BooksList.ItemsSource = new ObservableCollection<Book>();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                BooksList.ItemsSource = new ObservableCollection<Book>();
                BooksList.Visibility = Visibility.Hidden;
            }
            else
            {
              var filteredBooks = allBooks.Where(b => b.Title.ToLower().Contains(searchText)).ToList();
              BooksList.ItemsSource = new ObservableCollection<Book>(filteredBooks);

              if (filteredBooks.Count > 0) 
                BooksList.Visibility = Visibility.Visible;
            }

        }
    }


}
