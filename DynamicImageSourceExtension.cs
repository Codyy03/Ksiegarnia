using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Ksiegarnia.MarkupExtensions
{
    public class DynamicImageSourceExtension : MarkupExtension
    {
        public string FileName { get; set; }
        
        public DynamicImageSourceExtension(string fileName)
        {
            FileName = fileName;
        }
        // Konstruktor domyślny – potrzebny, aby XAML mógł utworzyć instancję i później ustawić właściwość FileName
        public DynamicImageSourceExtension() { }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // Jeśli FileName nie jest ustawiony, zwracamy null lub placeholder
            if (string.IsNullOrWhiteSpace(FileName))
            {
                return null;
            }

            string path = Path.Combine(
    Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,
    "Images");
            MessageBox.Show($"Ścieżka do obrazu: {path}"); // Debugowanie

            string fullPath = Path.Combine(path, FileName);

            if (!File.Exists(fullPath))
            {
                return new BitmapImage(); // Lub zwróć obraz zastępczy
            }

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullPath, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            return bitmap;
        }



    }
}
