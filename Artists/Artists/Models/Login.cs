using Artists.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Artists.Models
{
    public class Login
    {
        public static User User { get; private set; } = null;
        public static Boolean IsLoggedIn {
            get { return !(User == null); }
        }

        //public event EventHandler LogOut;

        //protected static void OnLogOut(EventArgs e)
        //{
        //    var changed = LogOut;
        //    if (changed == null)
        //        return;

        //    changed.Invoke(this, e);
        //}

        public static void Log_In(string username, string password)
        {
            User = new User { Username = username, Password = password };
        }

        public static void Log_Out()
        {
            User = null;
        }
    }
}
