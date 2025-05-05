using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
       
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            string path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "Images");
            string fullPath = Path.Combine(path, FileName);
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullPath, UriKind.Absolute);
            bitmap.EndInit();
            return bitmap;
        }

        
    }
}
