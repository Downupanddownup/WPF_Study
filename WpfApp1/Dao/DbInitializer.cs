using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Dao
{
    // DbInitializer.cs
    public class DbInitializer
    {
        private readonly DbConnectionFactory _connectionFactory;

        public DbInitializer(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Initialize()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                // 如果表 a 不存在，则创建它
                connection.Execute("CREATE TABLE IF NOT EXISTS a (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL);");
            }
        }
    }
}
