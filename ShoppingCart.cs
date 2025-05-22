using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Ksiegarnia.Entities;
using System.Text.Json;
using System.IO;
namespace Ksiegarnia
{
    public static class ShoppingCart
    {
        public static int itemsCounter = 0;

        public static ObservableCollection<Book> books = new ObservableCollection<Book>();

        public static bool booksWereLoad;

        public static void AddBookToCart(Button itemsCounterButton)
        {
            itemsCounterButton.Content = itemsCounter.ToString();
             
        }
        public static void ChangeWindowToCart()
        {
            ShoopingCartWindow shoopingCartWindow = new ShoopingCartWindow();
            shoopingCartWindow.Show();
        }
        public static decimal TotalPrice()
        {
            decimal totalPrice = 0;
            foreach (Book book in books)
                totalPrice += book.Price;

            return totalPrice;
        }
        public static void print()
        {
            MessageBox.Show(books[0].ID.ToString());
        }
        public static void SaveCartToJson()
        {
            try
            {
                string json = JsonSerializer.Serialize(books);
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "cart.json");

                if(!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                File.WriteAllText(path, json);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void LoadCartToJson()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "cart.json");

                if (File.Exists(path))  
                {
                    string json = File.ReadAllText(path); 
                    var loadedBooks = JsonSerializer.Deserialize<ObservableCollection<Book>>(json);

                    if (loadedBooks != null)
                    {
                        books.Clear();
                        itemsCounter = loadedBooks.Count;

                        foreach (var book in loadedBooks)
                        {
                            books.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd odczytu");
            }
        }

    }

}

