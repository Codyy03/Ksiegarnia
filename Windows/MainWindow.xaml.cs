using Ksiegarnia.Entities;
using Ksiegarnia.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace Ksiegarnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> allBooks { get; set; }
        ObservableCollection<Book> randomBooks = new ObservableCollection<Book>();
        DispatcherTimer debounceTimer;

        List<GroupedBookViewModel> groupedBooks = new List<GroupedBookViewModel>();
        public MainWindow()
        {
            InitializeComponent();

            if (!ShoppingCart.booksWereLoad)
            {
                ShoppingCart.LoadCartToJson();
                App.Current.Exit += (s, e) => ShoppingCart.SaveCartToJson();
                itemsInCartCounter.Content = ShoppingCart.itemsCounter.ToString();
                ShoppingCart.booksWereLoad = true;
            }

            ConnectionStringManager.ChangeUserNameNotification(UserButton);
           
            allBooks = new ObservableCollection<Book>();
            debounceTimer = new();
            debounceTimer.Interval = TimeSpan.FromSeconds(1f); // opóźnienie o 1 sekunde
            debounceTimer.Tick += DebounceTimer_Tick;

            var books = BookstoreContex.context.Books.Include(b => b.Author).ToList();

            Random random = new Random();
            while (randomBooks.Count < 3)
            {
                int randomBookIndex = random.Next(0, books.Count());

                if (TitleIsUnique(books[randomBookIndex].Title))
                {
                    randomBooks.Add(books[randomBookIndex]);
                    books.RemoveAt(randomBookIndex);
                }

            }
            RandomBooks.ItemsSource = new ObservableCollection<Book>(randomBooks);

            ShoppingCart.AddBookToCart(itemsInCartCounter);
        }

        bool TitleIsUnique(string title)
        {
            if (randomBooks.Count < 0) return true;

            foreach (Book book in randomBooks)
            {
                if (title == book.Title) return false;
            }

            return true;
        }
        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            string searchText = SearchBox.Text.Trim().ToLower();

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
                    var groupedBooks = BookstoreContex.context.Books
                      .Include(b => b.Author)
                      .GroupBy(b => new
                      {
                          b.Title,
                          b.CoverName,
                          b.Author.Name,
                          b.Author.Surname
                      })
                      .Select(g => new GroupedBookViewModel
                      {
                          Title = g.Key.Title,
                          CoverPath = g.First().CoverPath,
                          AuthorFullName = g.Key.Name + " " + g.Key.Surname,
                          Count = g.Count()
                      })
                      .ToList();

                    //  Filtracja zarówno po tytule książki, jak i po imieniu i nazwisku autora
                    var groupedBooks2 = groupedBooks
                       .Where(b => b.Title.ToLower().Contains(searchText)
                                || b.AuthorFullName.ToLower().Contains(searchText)) // Dodane wyszukiwanie autora
                       .GroupBy(b => b.Title)  // Grupowanie po tytule
                       .Select(g => g.First()) // Pobranie tylko pierwszej książki z każdej grupy
                       .ToList();

                    var filteredBooks = BookstoreContex.context.Books
                      .Where(b => b.Title.ToLower().Contains(searchText)
                               || (b.Author.Name.ToLower() + " " + b.Author.Surname.ToLower()).Contains(searchText)) // Filtrowanie po autorze
                      .GroupBy(b => b.Title)
                      .Select(g => g.First())
                      .ToList();

                    if (groupedBooks.Any())
                    {
                        BooksList.ItemsSource = new ObservableCollection<GroupedBookViewModel>(groupedBooks2).Take(5);
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
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            debounceTimer.Stop();
            debounceTimer.Start();
        }

        private void BooksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBook(BooksList);
        }
        private void RandomBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook =RandomBooks.SelectedItem as Book;
            if (selectedBook != null)
            {
                var detailsWindow = new BookDetailsWindow(selectedBook, groupedBooks);

                detailsWindow.Show();
                this.Close();
            }
        }

        public void SelectedBook(ListView listView)
        {
            GroupedBookViewModel selectedBookGroup = listView.SelectedItem as GroupedBookViewModel;
            if (selectedBookGroup != null)
            {

                var fullBook = BookstoreContex.context.Books
                    .Include(b => b.Author) // Pobieramy także autora
                    .FirstOrDefault(b => b.Title == selectedBookGroup.Title);

                if (fullBook != null)
                {
                    var detailsWindow = new BookDetailsWindow(fullBook, groupedBooks);
                    detailsWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie znaleziono szczegółów tej książki.");
                }
            }

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

        private void findAllBooks_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text) || BooksList.ItemsSource == null)
                return;

            AllBooksFound allBooksFound = new(BooksList);
            allBooksFound.Show();
            Close();
        }
        public void ShowUserPanel(Window window)
        {
            UserPanel userPanel = new UserPanel(this);
            userPanel.Show();
            window.Close();
        }
    }

}
