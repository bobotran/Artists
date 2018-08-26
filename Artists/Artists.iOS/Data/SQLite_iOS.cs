using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Artists.Data;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Artists.iOS.Data.SQLite_iOS))]

namespace Artists.iOS.Data
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var filename = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, filename);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}