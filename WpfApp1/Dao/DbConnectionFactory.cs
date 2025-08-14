using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Dao
{
    // DbConnectionFactory.cs
    public class DbConnectionFactory
    {
        private const string ConnectionString = "Data Source=MyDatabase.db";

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(ConnectionString);
        }
    }
}
