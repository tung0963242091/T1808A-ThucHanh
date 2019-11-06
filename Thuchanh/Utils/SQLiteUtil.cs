using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thuchanh.Utils
{
    class SQLiteUtil
    {
        private const string DatabaseName = "Contact.db";
        private static SQLiteUtil _instance;
        public SQLiteConnection Connection { get; }

        public static SQLiteUtil GetInstances()
        {
            if (_instance == null)
            {
                _instance = new SQLiteUtil();
            }

            return _instance;
        }

        private SQLiteUtil()
        {
            Connection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }


        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Note (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Name VARCHAR( 140 ),Content int(32);";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}
