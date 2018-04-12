using System;
using System.Collections.Generic;
using System.Globalization;
namespace Liuweiqian.Apps.Resume.Core.Converters
{
    using System.Windows.Data;
    /// <summary>
    /// 语言切换按钮与语言的转换
    /// </summary>
    public class LauguageToCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "en-US")
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return "en-US";
            else
                return "zh-CN";
        }
    }
}
