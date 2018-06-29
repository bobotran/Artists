using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Artists.BindingConverters
{
    //Converts DateTime to culturally recognizable Date strings
    public class DateConverter : IValueConverter
    {
        //Expects DateTime object type for value
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime source = (DateTime)value;

            return source.GetDateTimeFormats('d', culture)[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("DateConverter");
            throw new NotImplementedException();
        }
    }
}
