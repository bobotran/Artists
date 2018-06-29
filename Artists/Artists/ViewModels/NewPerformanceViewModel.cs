using Artists.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Artists.ViewModels
{
    public class NewPerformanceViewModel : BaseViewModel
    {
        public string PieceTitle { get; set; }
        public string Host { get; set; }
        public string Composer { get; set; }
        public Double Minutes { get; set; }
        public string Description { get; set; }

        private ObservableCollection<Part> parts;
        public ObservableCollection<Part> Parts
        {
            get { return parts; }
            set { SetProperty(ref parts, value); } }

        private string partNameEntryInput;
        public string PartNameEntryInput { get { return partNameEntryInput; } set { SetProperty(ref partNameEntryInput, value); } }


        private Color partNameEntryColor;
        public Color PartNameEntryColor { get { return partNameEntryColor; } set { SetProperty(ref partNameEntryColor, value); } }

        private Color performerNameEntryColor;
        public Color PerformerNameEntryColor { get { return performerNameEntryColor; } set { SetProperty(ref performerNameEntryColor, value); } }


        private string performerNameEntryInput;
        public string PerformerNameEntryInput { get { return performerNameEntryInput; } set { SetProperty(ref performerNameEntryInput, value); } }


        private Boolean partsButtonIsVisible;
        public Boolean PartsButtonIsVisible { get { return partsButtonIsVisible; }
            set { SetProperty(ref partsButtonIsVisible, value); }
        }

        
        
        public static Color HighlightedColor { get; set; } = Color.Red;

        public NewPerformanceViewModel()
        {
            Parts = new ObservableCollection<Part>
            {
                new Part{PartName = "Cello", Performer = new Performer {Name = "Megan" }},
                new Part{PartName = "Violin", Performer = new Performer {Name = "Shannon" }},
                new Part{PartName = "Voice", Performer = new Performer {Name = "Tiffany" }},
                new Part{PartName = "Cello", Performer = new Performer {Name = "Justin" } },
                new Part{PartName = "Violin", Performer = new Performer {Name = "Kevin" } }
            };
        }

        public void addPartFromEntries()
        {
            Parts.Add(new Part
            {
                PartName = PartNameEntryInput,
                Performer = new Performer { Name = PerformerNameEntryInput }
            });
        }

        public void resetNewPartEntries()
        {
            PartNameEntryInput = string.Empty;
            PerformerNameEntryInput = string.Empty;
            PartsButtonIsVisible = false;
            PartNameEntryColor = Part.DefaultPartNameColor;
            PerformerNameEntryColor = Performer.DefaultPerformerNameColor;
        }

        public void setNewPartEntriesTo(Part part)
        {
            PartNameEntryInput = part.PartName;
            PartNameEntryColor = part.PartNameColor;
            PerformerNameEntryInput = part.Performer.Name;
            PerformerNameEntryColor = part.Performer.NameColor;
        }

        public void updatePart(Part part)
        {
            part.PartName = PartNameEntryInput;
            part.Performer.Name = PerformerNameEntryInput;
        }
    }
}
