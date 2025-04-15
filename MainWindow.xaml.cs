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
            allBooks = new ObservableCollection<Book>
            {
                new Book {title = "Wiedzmin"},
                new Book {title = "Hobbit"},
                new Book {title = "Gra o tron"}
            };

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
              var filteredBooks = allBooks.Where(b => b.title.ToLower().Contains(searchText)).ToList();
              BooksList.ItemsSource = new ObservableCollection<Book>(filteredBooks);

              if (filteredBooks.Count > 0) 
                BooksList.Visibility = Visibility.Visible;
            }

        }
    }

    public class Book {
        public string title { get; set; }
        

    }
}
