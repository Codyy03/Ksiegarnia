using Ksiegarnia.Entities;
using System;
using System.Collections.Generic;
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

namespace Ksiegarnia.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AllBooksFound.xaml
    /// </summary>
    public partial class AllBooksFound : Window
    {
        public AllBooksFound(ListView listView)
        {
            InitializeComponent();
            FoundBooks.ItemsSource = listView.ItemsSource;
        }
        private void UserButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void itemsInCartCounter_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart.ChangeWindowToCart();

        }
      
        void FoundBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.SelectedBook(FoundBooks);
        }
    }
}
