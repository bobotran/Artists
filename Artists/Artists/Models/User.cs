using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Artists.Models
{
    public class User
    {
        public static Color DefaultPerformerNameColor { get; set; } = Color.Black;

        public Color NameColor { get; set; } = DefaultPerformerNameColor;



        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string Username { get; set; }
    }
}
