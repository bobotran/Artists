using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Artists.ViewModels;

namespace Artists.Models
{
    public class Part : BaseModel
    {
        public static Color DefaultPartNameColor { get; set; } = Color.Blue;
        private string partName;
        public string PartName { get { return partName; } set { SetProperty(ref partName, value); } }

        private Color partNameColor = DefaultPartNameColor;
        public Color PartNameColor { get { return partNameColor; } set { SetProperty(ref partNameColor, value); } }

        private Performer performer;
        public Performer Performer { get { return performer; } set { SetProperty(ref performer, value); } }

        public override string ToString()
        {
            return PartName + ": " + Performer.Name;
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
