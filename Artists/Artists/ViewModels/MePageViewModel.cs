using Artists.Models;
using Artists.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Artists.ViewModels
{
    public class MePageViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public Command LoadItemsCommand { get; set; }
        public MePageViewModel()
        {
            Users = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<LoginPage, User>(this, "AddUser",  (obj, item) =>
            {
                var user = item as User;

                Users.Add(user);
                //App.Database.SaveItemAsync(user);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Users.Clear();
                //var items = await App.Database.GetItemsAsync();
                //foreach (User item in items)
                //{
                //    Users.Add(item);
                //}
            }
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
            finally
            {
                IsBusy = false;
            }
        }
    }
}
