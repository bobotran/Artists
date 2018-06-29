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
            String floor;
            switch (floorInt)
            {
              case 0: return "";
              case 1: floor = floorInt.toString() + "st Floor";
                      return floor;
              case 2: floor = floorInt.toString() + "nd Floor";
                      return floor;
              case 3: floor = floorInt.toString() + "rd Floor";
                      return floor;
              case 11: floor = floorInt.toString() + "th Floor";
                        return floor;
              case 12: floor = floorInt.toString() + "th Floor";
                        return floor;
              case 13: floor = floorInt.toString() + "th Floor";
                        return floor;
              case 10: floor = floorInt.toString() + "th Floor";
                        return floor;
            }
            int newFloorInt = (floorInt % 10);
            switch (newFloorInt)
            {
              case 1: floor = floorInt.toString() + "st Floor";
                      return floor;
              case 2: floor = floorInt.toString() + "nd Floor";
                      return floor;
              case 3: floor = floorInt.toString() + "rd Floor";
                      return floor;
            }
            return (floorInt.toString() + "th Floor");



            // if (floorInt > 10)
            // {
            //   if (floorInt < 14)
            //   {
            //     floor = floorInt.toString() + "th Floor";
            //   }
            //   else if ((floorInt % 10) == 1)
            //   {
            //     floor = floorInt.toString() + "st Floor";
            //   }
            //   else if ((floorInt % 10) == 2)
            //   {
            //     floor = floorInt.toString() + "nd Floor";
            //   }
            //   else if ((floorInt % 10) == 3)
            //   {
            //     floor = floorInt.toString() + "rd Floor";
            //   }
            //   else
            //   {
            //     floor = floorInt.toString() + "th Floor";
            //   }
            // }
            //
            // else if (floorInt == 1)
            // {
            //   floor = floorInt.toString() + "st Floor";
            // }
            //
            // else if (floorInt == 2)
            // {
            //   floor = floorInt.toString() + "nd Floor";
            // }
            //
            // else if (floorInt == 3)
            // {
            //   floor = floorInt.toString() + "rd Floor";
            // }
            //
            // else
            // {
            //   floor = floorInt.toString() + "th Floor";
            // }

        }
        //Don't implement
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
