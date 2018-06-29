using Artists.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Artists.BindingConverters
{
    //Converts a List<Part> into a string
    public class PartsConverter : IValueConverter
    {
        //Expects List<Part> as type for value
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parts = value as List<Part>;
            if(parts == null) { return null; }
            List<string> stringParts = new List<string>();
            foreach(Part part in parts)
            {
                stringParts.Add(part.ToString());
            }
            string combindedString = string.Join(" | ", stringParts);
            return combindedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("PartsConverter");
            throw new NotImplementedException();
        }
    }
}
