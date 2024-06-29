using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Provider;
using System.Windows.Data;

namespace CosmeticHealth.Converters
{
    public class HasErrorsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(obj => obj is null))
            {
                return false;
            }
            return values.Cast<bool>().All(hasError=>!hasError);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
