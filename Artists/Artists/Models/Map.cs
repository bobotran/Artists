using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Artists.Models
{
    public class Map
    {
        public static void LaunchMapApp(Place place)
        {
            // Windows Phone doesn't like ampersands in the names and the normal URI escaping doesn't help
            var name = place.Name.Replace("&", "and"); // var name = Uri.EscapeUriString(place.Name);
            var loc = string.Format("{0},{1}", place.Latitude, place.Longitude);
            var addr = Uri.EscapeUriString(place.Vicinity);

            var request = Device.OnPlatform(
              // iOS doesn't like %s or spaces in their URLs, so manually replace spaces with +s
              string.Format("http://maps.apple.com/maps?q={0}&sll={1}", name.Replace(' ', '+'), loc),

              // pass the address to Android if we have it
              string.Format("geo:0,0?q={0}({1})", string.IsNullOrWhiteSpace(addr) ? loc : addr, name),

              // WinPhone
              string.Format("bingmaps:?cp={0}&q={1}", loc, name)
            );

            Device.OpenUri(new Uri(request));
        }
    }
}
