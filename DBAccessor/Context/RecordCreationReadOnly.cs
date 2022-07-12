using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace DBAccessor.Context
{
    public class RecordCreationReadOnly
    {
        public IDbConnection Db { get; }
        public IConfiguration DbConnectionString{ get; }
        public RecordCreationReadOnly()
        {
            Db = GetConnection();
        }
        public IDbConnection GetConnection()
        {
            string connstring = DbConnectionString.GetConnectionString("SQLiteConnection");
            var conn = new SqliteConnection(connstring);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
