using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Artists.Models
{
    public class Performer : BaseModel
    {
        public static Color DefaultPerformerNameColor { get; set; } = Color.Black;

        private string name;
        public string Name { get { return name; } set { SetProperty(ref name, value); } }

        private Color nameColor = DefaultPerformerNameColor;
        public Color NameColor { get { return nameColor; } set { SetProperty(ref nameColor, value); } }

    }
}
