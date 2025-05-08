﻿using Ksiegarnia.Entities;
using Ksiegarnia.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
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

        public MainWindow()
        {
            InitializeComponent();
            allBooks = new ObservableCollection<Book>();
            debounceTimer = new();
            debounceTimer.Interval = TimeSpan.FromSeconds(1f); // opóźnienie o 1 sekunde
            debounceTimer.Tick += DebounceTimer_Tick;

                var books = BookstoreContex.context.Books.Include(b => b.Author).ToList();

                Random random = new Random();
                for (int i = 0; i < 3; i++)
                {
                    int randomBookIndex = random.Next(0, books.Count());
                    randomBooks.Add(books[randomBookIndex]);
                    books.RemoveAt(randomBookIndex);

                }
                RandomBooks.ItemsSource = new ObservableCollection<Book>(randomBooks);
            
            ShoppingCart.AddBookToCart(itemsInCartCounter);
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
                        var filteredBooks = BookstoreContex.context.Books
                            .Include(b => b.Author)
                            .Where(b => b.Title.ToLower().Contains(searchText))
                            .ToList();

                        if (filteredBooks.Any())
                        {
                            BooksList.ItemsSource = new ObservableCollection<Book>(filteredBooks).Take(5);
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
            SelectedBook(RandomBooks);
        }

        public void SelectedBook(ListView listView)
        {
            Book selectedBook = listView.SelectedItem as Book;
            if (selectedBook != null)
            {
                var detailsWindow = new BookDetailsWindow(selectedBook);
                detailsWindow.Show();

                this.Close();
            }
        }
        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            ShowUserPanel(this);
        }

        private void itemsInCartCounter_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart.ChangeWindowToCart();
        }

        private void findAllBooks_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text) || BooksList.ItemsSource==null)
                return;

            AllBooksFound allBooksFound = new(BooksList);
            allBooksFound.Show();
        }
        public void ShowUserPanel(Window window)
        {
            UserPanel userPanel = new UserPanel(this);
            userPanel.Show();
            window.Close();
        }
    }
   
}
