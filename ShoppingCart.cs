using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Ksiegarnia.Entities;

namespace Ksiegarnia
{
    public static class ShoppingCart
    {
        public static int itemsCounter = 0;

        public static ObservableCollection<Book> books = new ObservableCollection<Book>();

        public static void AddBookToCart(Button itemsCounterButton)
        {
            itemsCounterButton.Content = itemsCounter.ToString();
             
        }
        public static void ChangeWindowToCart()
        {
            ShoopingCartWindow shoopingCartWindow = new ShoopingCartWindow();
            shoopingCartWindow.Show();
        }
    }

}

