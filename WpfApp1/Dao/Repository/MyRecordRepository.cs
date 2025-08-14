using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Bean;

namespace WpfApp1.Dao.Repository
{
    // MyRecordRepository.cs
    public class MyRecordRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public MyRecordRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<MyRecord> GetAll()
        {
            const string sql = "SELECT name FROM a;";
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<MyRecord>(sql).ToList();
            }
        }

        public void Insert(MyRecord record)
        {
            const string sql = "INSERT INTO a (name) VALUES (@Name);";
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute(sql, record);
            }
        }
    }
}
