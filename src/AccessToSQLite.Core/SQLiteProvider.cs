using System.Data.SQLite;
using System.IO;

namespace AccessToSQLite.Core
{
    public class SQLiteProvider
    {
        private readonly string _fileName;

        public SQLiteProvider(string fileName)
        {
            _fileName = fileName;
        }

        private string ConnectionString => $"Data Source={_fileName};Version=3;";

        public SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(ConnectionString);
            return conn.OpenAndReturn();
        }

        public void CreateDatabase()
        {
            if (File.Exists(_fileName))
                File.Delete(_fileName);

            SQLiteConnection.CreateFile(_fileName);
        }
    }
}
