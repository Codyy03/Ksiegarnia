using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Ksiegarnia
{
    /// <summary>
    /// Logika interakcji dla klasy ShoopingCartWindow.xaml
    /// </summary>
    public partial class ShoopingCartWindow : Window
    {
        
        public ShoopingCartWindow()
        {
            InitializeComponent();

            BooksInShoopingCart.ItemsSource = ShoppingCart.books;

            decimal totalPrice = 0;

            foreach(Book book in ShoppingCart.books)
                totalPrice += book.Price;

            TotalPrice.Text =$"Kwota końcowa: {totalPrice.ToString()} zł";


        }

    }
}
