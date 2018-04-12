namespace Liuweiqian.Apps.Resume.Core.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    public class SwitchThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Theme)
            {
                if ((Theme)value == Theme.BaseLight)
                    return false;
                else
                    return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return Theme.BaseDark;
                else
                    return Theme.BaseLight;
            }
            return Theme.BaseLight;
        }
    }
}
