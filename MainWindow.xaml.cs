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
using System.Windows.Threading;

namespace Ksiegarnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> allBooks { get; set; }
        DispatcherTimer debounceTimer;
        public MainWindow()
        {
            InitializeComponent();
            allBooks = new ObservableCollection<Book>();
            debounceTimer = new();
            debounceTimer.Interval = TimeSpan.FromSeconds(0.9f); // opóźnienie o 2 sekunde
            debounceTimer.Tick += DebounceTimer_Tick;

        }
        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop(); //  Zatrzymanie timera po wykonaniu operacji
            string searchText = SearchBox.Text.ToLower();
            using (BookstoreContex context = new BookstoreContex())
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    BooksList.ItemsSource = new ObservableCollection<Book>();
                    BooksList.Visibility = Visibility.Hidden;
                }
                else
                {
                    try
                    {
                        var filteredBooks = context.Books.Where(b => b.Title.ToLower().Contains(searchText)).ToList();
                        BooksList.ItemsSource = new ObservableCollection<Book>(filteredBooks);
                        if (filteredBooks.Count > 0)
                            BooksList.Visibility = Visibility.Visible;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            debounceTimer.Stop();
            debounceTimer.Start();
        }
    }


}
