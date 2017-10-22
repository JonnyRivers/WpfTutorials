using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WpfTreeViewsAndValueConverters.Directory.Data;

namespace WpfTreeViewsAndValueConverters
{
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DirectoryItemType type = (DirectoryItemType)value;

            var imageFileName = "file.png";

            switch (type)
            {
                case DirectoryItemType.Drive:
                    imageFileName = "drive.png";
                    break;
                case DirectoryItemType.Folder:
                    imageFileName = "folder-closed.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/Images/{imageFileName}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
