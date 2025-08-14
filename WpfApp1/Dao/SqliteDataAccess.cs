using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Bean;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace WpfApp1.Dao
{
    public class SqliteDataAccess
    {
        private const string ConnectionString = "Data Source=MyDatabase.db";

        public SqliteDataAccess()
        {
            // 确保数据库文件和表在实例创建时被初始化
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            // 使用 "CREATE TABLE IF NOT EXISTS" 语法来安全地创建表
            // 如果表 a 已经存在，这条语句不会做任何事
            const string createTableSql = "CREATE TABLE IF NOT EXISTS a (name TEXT NOT NULL);";

            using (IDbConnection connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                // 使用 Dapper 的 Execute 方法来执行非查询操作
                connection.Execute(createTableSql);

                // 额外添加一些测试数据，以便首次运行时有内容可查
                const string insertSql = "INSERT INTO a (name) VALUES (@Name);";
                connection.Execute(insertSql, new { Name = "测试数据1" });
                connection.Execute(insertSql, new { Name = "测试数据2" });
            }
        }

        public List<MyRecord> GetAllRecords()
        {
            const string sql = "SELECT name FROM a;";

            using (IDbConnection connection = new SqliteConnection(ConnectionString))
            {
                return connection.Query<MyRecord>(sql).ToList();
            }
        }
    }
}
