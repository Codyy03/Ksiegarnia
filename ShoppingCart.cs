using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ksiegarnia
{
    public static class ShoppingCart
    {
        public static int itemsCounter = 0;

        public static List<Book> books = new List<Book>();

        public static void PrintBooks()
        {
            foreach (Book book in books)
            {
                MessageBox.Show(book.Title);
            }
        }
    }

}

