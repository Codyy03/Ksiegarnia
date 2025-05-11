using Ksiegarnia.Entities;
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

namespace Ksiegarnia.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Pobieramy zamówienia wraz z powiązanymi klientami oraz produktami (książkami) w zamówieniu.
                var ordersList = BookstoreContex.context.Orders
                    .Include(o => o.Customer)  // pobiera dane klienta związane z zamówieniem
                    .Include(o => o.OrderBooks) // pobiera relację z książkami
                        .ThenInclude(ob => ob.Book) // pobiera dane o książce
                    .ToList();

                // Przykładowo przypisujemy dane do DataGrid
                OrdersDataGrid.ItemsSource = new ObservableCollection<Orders>(ordersList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania zamówień: " + ex.Message);
            }
        }
        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                // Konwertujemy Tag do int (ID zamówienia)
                int orderId = Convert.ToInt32(btn.Tag);

                // wyświetlanie okienka potwierdzenia usunięcia
                var result = MessageBox.Show("Czy na pewno chcesz usunąć to zamówienie?",
                                             "Potwierdzenie usunięcia",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {

                        // Pobierz zamówienie wraz z listą OrderBooks
                        var orderToDelete = BookstoreContex.context.Orders
                            .Include(o => o.OrderBooks)
                            .FirstOrDefault(o => o.ID == orderId);

                        if (orderToDelete != null)
                        {
                            BookstoreContex.context.Orders.Remove(orderToDelete);
                            BookstoreContex.context.SaveChanges();

                            MessageBox.Show("Zamówienie zostało usunięte.");

                            // trzeba ponownie załadować dane
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono zamówienia o podanym ID.");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wystąpił błąd podczas usuwania zamówienia: " + ex.Message);
                    }
                }
            }
        }

        private void backToSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
