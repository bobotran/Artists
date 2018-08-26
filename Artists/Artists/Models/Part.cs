using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Artists.ViewModels;

namespace Artists.Models
{
    public class Part 
    {
        public int Id { get; set; }
        public static Color DefaultPartNameColor { get; set; } = Color.Blue;
        public string PartName { get;set; }

        public Color PartNameColor { get; set; } = DefaultPartNameColor;

        public User Performer { get; set; }

        public override string ToString()
        {
            return PartName + ": " + Performer.Username;
        }

        public void setNameColors(Color partNameColor, Color performerNameColor)
        {
            PartNameColor = partNameColor;
            Performer.NameColor = performerNameColor;
        }

        public void setNameColors(Color color)
        {
            PartNameColor = color;
            Performer.NameColor = color;
        }
    }
}
