using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Artists.BindingConverters;
using Artists.Models;
using Xamarin.Forms;

namespace Artists.ViewModels
{
    public class EventDetailViewModel : BaseViewModel
    {
        public Event Event { get; set; }
        public Command LoadPerformancesCommand { get; set; }


        private string addressButtonText;
        private string addressBuildingLabel;
        private string addressFloorLevelLabel;
        private string nicknameLabel;
        private string dressCodeLabel;
        private string dateLabel;
        private string startTimeLabel;
        private string endTimeLabel;


        public string AddressButtonText { get { return addressButtonText; } set { SetProperty(ref addressButtonText, value); } }
        public string AddressBuildingLabel { get { return addressBuildingLabel; } set { SetProperty(ref addressBuildingLabel, value); } }
        public string AddressFloorLevelLabel { get { return addressFloorLevelLabel; } set { SetProperty(ref addressFloorLevelLabel, value); } }
        public string NicknameLabel { get { return nicknameLabel; } set { SetProperty(ref nicknameLabel, value); } }
        public string DressCodeLabel { get { return dressCodeLabel; } set { SetProperty(ref dressCodeLabel, value); } }
        public string DateLabel { get { return dateLabel; } set { SetProperty(ref dateLabel, value); } }
        public string StartTimeLabel { get { return startTimeLabel; } set { SetProperty(ref startTimeLabel, value); } }
        public string EndTimeLabel { get { return endTimeLabel; } set { SetProperty(ref endTimeLabel, value); } }
        public ObservableCollection<Performance> Performances { get; set; }

        private Place place { get { return new Place { Name = Event.Address.AddressLine, Vicinity = Event.Address.City }; } }
        public EventDetailViewModel(Event ev = null)
        {
            //Title = ev?.Nickname;
            Event = ev;
            Performances = new ObservableCollection<Performance>();

            LoadPerformancesCommand = new Command( () =>  ExecuteLoadItemsCommand());
        }

        void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Performances.Clear();
                var items = Event.Performances;
                foreach (var item in items)
                {
                    Performances.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void openMap()
        {
            Map.LaunchMapApp(place);
        }
        public void updateBindings()
        {
            ExecuteLoadItemsCommand();
            if(Event.Address != null)
            {
                AddressButtonText = Event.Address.AddressLine + ", " + Event.Address.City;
                AddressBuildingLabel = Event.Address.Building;
                AddressFloorLevelLabel = FloorConverter.ConvertToString(Event.Address.FloorLevel);
            }
            
            NicknameLabel = Event.Nickname;
            DateLabel = DateConverter.ConvertToString(Event.StartTime);
            StartTimeLabel = TimeConverter.ConvertToString(Event.StartTime);
            EndTimeLabel = TimeConverter.ConvertToString(Event.EndTime);
            DressCodeLabel = Event.DressCode;
        }
    }
}
