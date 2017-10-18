using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace AccessToSQLite.Core
{
    public class Export
    {
        private readonly AccessExportOptions _options;
        private readonly SQLiteProvider _sqliteProvider;

        public Export(AccessExportOptions options)
        {
            _options = options;
            _sqliteProvider = new SQLiteProvider(options.SQLiteFileName);
        }

        public ExportResult Execute()
        {
            DataSet ds = null;

            try
            {
                ds = AccessDbLoader.LoadFromFile(_options.AccessFileName, _options.AccessPassword);

                _sqliteProvider.CreateDatabase();

                foreach (var table in ds.Tables.Cast<DataTable>())
                {
                    var tableSql = ImportTable(table);
                    using (var conn = _sqliteProvider.GetConnection())
                        conn.Execute(tableSql);

                    InsertData(table);
                }
            }
            catch (OleDbException ex)
            {
                if (ex.Message == "Not a valid password.")
                    return ExportResult.PasswordInvalid;
                
                return ExportResult.ImportError;
            }

            return ExportResult.Success;
        }

        private void InsertData(DataTable table)
        {
            var columns = table.Columns.Cast<DataColumn>();
            var columnSql = string.Join(", ", columns.Select(x => x.FixedColumnName()));
            var paramSql = string.Join(", ", columns.Select(x => "@" + x.FixedColumnName()));
            var tableName = table.FixedTableName();
            var insertSql = $"INSERT INTO {tableName} ({columnSql}) VALUES ({paramSql})";

            using (var conn = _sqliteProvider.GetConnection())
            using (var tx = conn.BeginTransaction())
            {
                foreach (DataRow row in table.Rows)
                {
                    var param = new Dictionary<string, object>();
                    foreach (var c in columns)
                    {
                        var val = row[c];
                        if (c.AllowDBNull && val == DBNull.Value)
                            val = null;
                        param.Add(c.FixedColumnName(), val);
                    }

                    conn.Execute(insertSql, param, tx);
                }

                tx.Commit();
            }
        }
        
        private string ImportTable(DataTable dataTable)
        {
            var tableName = dataTable.FixedTableName();

            var columns = new List<string>();
            foreach (var dataColumn in dataTable.Columns.Cast<DataColumn>())
                columns.Add(ImportColumn(dataColumn));

            var columnSql = string.Join(", ", columns);

            if (dataTable.PrimaryKey.Count() > 0)
                Console.WriteLine(dataTable.PrimaryKey);

            // TODO: Primary Key, Foreign Keys etc.
            var sql = $"CREATE TABLE {tableName} ({columnSql})";

            return sql;
        }

        private class ImportTableResult
        {
            public string Sql { get; set; }
            public string[] ColumnNames { get; set; }
        }

        private string ImportColumn(DataColumn dataColumn)
        {
            var dataType = ResolveColumnDataType(dataColumn);
            var notNull = dataColumn.AllowDBNull ? string.Empty : " NOT NULL";
            var defaultVal = dataColumn.DefaultValue.ToString();
            var defaultValText = string.IsNullOrEmpty(defaultVal) ? string.Empty : $" DEFAULT {defaultVal}";
            var columnName = dataColumn.FixedColumnName();
            var sql = $"{columnName} {dataType}{notNull}{defaultValText}";
            return sql;
        }

        private string ResolveColumnDataType(DataColumn dataColumn)
        {
            var type = dataColumn.DataType;

            if (type == typeof(int) || type == typeof(short) || type == typeof(long) || type == typeof(bool))
                return "INTEGER";
            else if (type == typeof(string) || type == typeof(DateTime))
                return "TEXT";
            else if (type == typeof(float) || type == typeof(double) || type == typeof(decimal))
                return "REAL";

            throw new Exception("Unknown Column Type");
        }
    }

    public static class DataTableExtensions
    {
        public static string FixedTableName(this DataTable table)
        {
            // Remove leading and trailing square brackets.
            // Table names should not contain ampersands or spaces.
            return table.TableName.Trim('[', ']').Replace("&", "_and_").Replace(' ', '_');
        }
    }

    public static class DataColumnExtensions
    {
        private static string[] ReservedKeyWords = new string[]
        {
            "ABORT",
            "ACTION",
            "ADD",
            "AFTER",
            "ALL",
            "ALTER",
            "ANALYZE",
            "AND",
            "AS",
            "ASC",
            "ATTACH",
            "AUTOINCREMENT",
            "BEFORE",
            "BEGIN",
            "BETWEEN",
            "BY",
            "CASCADE",
            "CASE",
            "CAST",
            "CHECK",
            "COLLATE",
            "COLUMN",
            "COMMIT",
            "CONFLICT",
            "CONSTRAINT",
            "CREATE",
            "CROSS",
            "CURRENT_DATE",
            "CURRENT_TIME",
            "CURRENT_TIMESTAMP",
            "DATABASE",
            "DEFAULT",
            "DEFERRABLE",
            "DEFERRED",
            "DELETE",
            "DESC",
            "DETACH",
            "DISTINCT",
            "DROP",
            "EACH",
            "ELSE",
            "END",
            "ESCAPE",
            "EXCEPT",
            "EXCLUSIVE",
            "EXISTS",
            "EXPLAIN",
            "FAIL",
            "FOR",
            "FOREIGN",
            "FROM",
            "FULL",
            "GLOB",
            "GROUP",
            "HAVING",
            "IF",
            "IGNORE",
            "IMMEDIATE",
            "IN",
            "INDEX",
            "INDEXED",
            "INITIALLY",
            "INNER",
            "INSERT",
            "INSTEAD",
            "INTERSECT",
            "INTO",
            "IS",
            "ISNULL",
            "JOIN",
            "KEY",
            "LEFT",
            "LIKE",
            "LIMIT",
            "MATCH",
            "NATURAL",
            "NO",
            "NOT",
            "NOTNULL",
            "NULL",
            "OF",
            "OFFSET",
            "ON",
            "OR",
            "ORDER",
            "OUTER",
            "PLAN",
            "PRAGMA",
            "PRIMARY",
            "QUERY",
            "RAISE",
            "RECURSIVE",
            "REFERENCES",
            "REGEXP",
            "REINDEX",
            "RELEASE",
            "RENAME",
            "REPLACE",
            "RESTRICT",
            "RIGHT",
            "ROLLBACK",
            "ROW",
            "SAVEPOINT",
            "SELECT",
            "SET",
            "TABLE",
            "TEMP",
            "TEMPORARY",
            "THEN",
            "TO",
            "TRANSACTION",
            "TRIGGER",
            "UNION",
            "UNIQUE",
            "UPDATE",
            "USING",
            "VACUUM",
            "VALUES",
            "VIEW",
            "VIRTUAL",
            "WHEN",
            "WHERE",
            "WITH",
            "WITHOUT",
        };

        public static string FixedColumnName(this DataColumn column)
        {
            // Column names should not contain spaces or periods.
            var columnName = column.ColumnName.Trim().Replace(' ', '_').Replace('.', '_');
            // Restrict column names from containing reserved SQLite keywords.
            if (ReservedKeyWords.Contains(columnName.ToUpper()))
                return columnName + "_";
            return columnName;
        }
    }

    public enum ExportResult
    {
        Success,
        PasswordInvalid,
        ImportError,
    }
}
