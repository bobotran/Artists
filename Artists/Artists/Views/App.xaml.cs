using System;
using Xamarin.Forms;
using Artists.Views;
using Xamarin.Forms.Xaml;
using Artists.Data;
using System.IO;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Artists
{
	public partial class App : Application
	{
        //static TokenDatabaseController tokenDatabase;
        //public static TokenDatabaseController TokenDatabase
        //{
        //    get
        //    {
        //        if (tokenDatabase == null)
        //        {
        //            tokenDatabase = new TokenDatabaseController();
        //        }
        //        return tokenDatabase;
        //    }
        //}

        //static UserDatabaseController userDatabase;
        //public static UserDatabaseController UserDatabase
        //{
        //    get
        //    {
        //        if (userDatabase == null)
        //        {
        //            userDatabase = new UserDatabaseController();
        //        }
        //        return userDatabase;
        //    }
        //}
        //private static UserDatabase database;
        //public static UserDatabase Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new UserDatabase(
        //              Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
        //        }
        //        return database;
        //    }
        //}

        public App ()
		{
			InitializeComponent();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.Event, DTOs.EventForCreationDto>();
            });

            MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
