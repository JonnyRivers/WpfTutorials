using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeViewsAndValueConverters
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;

            if (path == null)
                return null;

            var imageFileName = "file.png";

            var name = Path.GetFileName(path);
            if (String.IsNullOrEmpty(name))
                imageFileName = "drive.png";
            else
            {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Attributes.HasFlag(FileAttributes.Directory))
                    imageFileName = "folder-closed.png";
            }

            return new BitmapImage(new Uri($"pack://application:,,,/Images/{imageFileName}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
