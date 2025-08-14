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
            const string sql = "SELECT id as Id, name FROM a;";
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

        public void Update(int id, MyRecord record)
        {
            const string sql = "UPDATE a SET name = @Name WHERE id = @Id;";
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute(sql, new { Name = record.Name, Id = id });
            }
        }

        public void Delete(int id)
        {
            const string sql = "DELETE FROM a WHERE id = @Id;";
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute(sql, new { Id = id });
            }
        }

        public List<MyRecord> Search(string name)
        {
            const string sql = "SELECT id as Id, name FROM a WHERE name LIKE @Name;";
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<MyRecord>(sql, new { Name = $"%{name}%" }).ToList();
            }
        }
    }
}
