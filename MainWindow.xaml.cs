using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            debounceTimer.Interval = TimeSpan.FromSeconds(1f); // opóźnienie o 1 sekunde
            debounceTimer.Tick += DebounceTimer_Tick;
      

            using (BookstoreContex contex = new BookstoreContex(ContextOptions()))
            {
                var books = contex.Books.ToList();

                var randomBooks = new ObservableCollection<Book>();
                Random random = new Random();
                for(int i=0; i<3; i++)
                {
                    int randomBookIndex = random.Next(0, books.Count());
                    randomBooks.Add(books[randomBookIndex]);
                    books.RemoveAt(randomBookIndex);
                    
                }
                RandomBooks.ItemsSource = new ObservableCollection<Book>(randomBooks);
            }

        }
        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            string searchText = SearchBox.Text.Trim().ToLower();
           
            using (BookstoreContex context = new BookstoreContex(ContextOptions()))
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    AdvertisementImage.Visibility = Visibility.Visible;
                    BooksList.ItemsSource = null;
                    BooksList.Visibility = Visibility.Hidden;
                }
                else
                {
                    try
                    {
                        var filteredBooks = context.Books
                            .Include(b => b.Author)
                            .Where(b => b.Title.ToLower().Contains(searchText))
                            .ToList();

                        if (filteredBooks.Any())
                        {
                            BooksList.ItemsSource = new ObservableCollection<Book>(filteredBooks);
                            BooksList.Visibility = Visibility.Visible;

                            // Ukrywamy reklamę, gdy pojawiają się wyniki wyszukiwania
                            AdvertisementImage.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            BooksList.ItemsSource = null;
                            BooksList.Visibility = Visibility.Hidden;
                            AdvertisementImage.Visibility = Visibility.Visible;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd podczas wyszukiwania: " + ex.Message);
                    }
                }
            }
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            debounceTimer.Stop();
            debounceTimer.Start();
        }

        private void BooksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedBook = BooksList.SelectedItem as Book;

            if (selectedBook != null)
            {
                var detailsWindow = new BookDetailsWindow(selectedBook);
                detailsWindow.Show();

                this.Close();
            }
        }
        private DbContextOptions<BookstoreContex> ContextOptions()
        {
            string path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName);
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configurationBuilder.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string 'DefaultConnection' is null or empty.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<BookstoreContex>();
            optionsBuilder.UseNpgsql(connectionString); // Konfiguracja połączenia do PostgreSQL
            return optionsBuilder.Options;
        }

    }
}
