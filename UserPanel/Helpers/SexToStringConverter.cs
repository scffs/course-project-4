using System.Globalization;
namespace UserPanel.Helpers
{
    public class SexToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "Не указано";
            if (value is int sexInt)
            {
                return sexInt == 1 ? "Мужской" : "Женский";
            }
            else if (value is bool sexBool)
            {
                return sexBool ? "Мужской" : "Женский";
            }
            else if (value is string sexString && int.TryParse(sexString, out var parsedInt))
            {
                return parsedInt == 1 ? "Мужской" : "Женский";
            }
            return "Не указано";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}