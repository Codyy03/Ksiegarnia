using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            debounceTimer.Interval = TimeSpan.FromSeconds(0.9f); // opóźnienie o 2 sekunde
            debounceTimer.Tick += DebounceTimer_Tick;

            using (BookstoreContex contex = new BookstoreContex())
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

            using (BookstoreContex context = new BookstoreContex())
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
            }
        }
    }
}
