using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artists.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
