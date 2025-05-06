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
    /// Logika interakcji dla klasy UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        public UserPanel(Window window)
        {
            InitializeComponent();

        }
        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            CloseWindows();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CloseWindows();
        }
        void CloseWindows()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
