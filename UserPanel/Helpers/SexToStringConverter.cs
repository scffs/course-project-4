using System.Globalization;

namespace UserPanel.Helpers
{
    internal class SexToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int sexInt)
            {
                return sexInt == 1 ? "Мужской" : "Женский";
            }
            return "Не указано";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
