using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Artists.BindingConverters
{
    public class FloorConverter : IValueConverter
    {
        /**
         * Convert an int into a floor label
         * Ex: 1 --> 1st Floor
         * Ex: 22 --> 22nd Floor
         * */
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int floorInt = (int)value;
            return "";
        }
        //Don't implement
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
