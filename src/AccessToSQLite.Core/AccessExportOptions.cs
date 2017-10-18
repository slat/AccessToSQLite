using System.IO;

namespace AccessToSQLite.Core
{
    public class AccessExportOptions
    {
        private string _accessFileName;

        public string AccessFileName
        {
            get { return _accessFileName; }
            set
            {
                _accessFileName = value;
                SQLiteFileName = Path.Combine(SQLiteInitialDirectory, SQLiteDefaultFileName);
            }
        }

        public string AccessPassword { get; set; }

        public string SQLiteFileName { get; set; }

        public bool Executing { get; set; }
        
        public bool CanExport => File.Exists(AccessFileName) && !Executing && !string.IsNullOrEmpty(SQLiteFileName);

        public bool SQLiteFileExists => File.Exists(SQLiteFileName);

        public string SQLiteInitialDirectory => Path.GetDirectoryName(AccessFileName);

        public string SQLiteDefaultFileName => Path.GetFileNameWithoutExtension(AccessFileName) + ".sqlite3";
    }
}
