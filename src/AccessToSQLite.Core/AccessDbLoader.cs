/* 
 * Microsoft Access Database DataSet Loader for .NET
 * Version 20150511
 *
 * Created by SiZiOUS
 * sizious (at) gmail (dot) com - @sizious - www.sizious.com - fb.com/sizious
 *
 * Licensed under the WTFPL licence
 * See http://www.wtfpl.net/txt/copying/
 */

using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace AccessToSQLite.Core
{
    /// <summary>
    /// Useful utilities for Microsoft Access Database files.
    /// </summary>
    public static class AccessDbLoader
    {
        /// <summary>
        /// Loads a Microsoft Access Database file into a DataSet object.
        /// The file can be the in the newer ACCDB format or MDB legacy format.
        /// </summary>
        /// <param name="fileName">The file name to load.</param>
        /// <returns>A DataSet object with the Tables object populated with the contents of the specified Microsoft Access Database.</returns>
        public static DataSet LoadFromFile(string fileName, string password=null)
        {
            DataSet result = new DataSet();

            // For convenience, the DataSet is identified by the name of the loaded file (without extension).
            result.DataSetName = Path.GetFileNameWithoutExtension(fileName).Replace(" ", "_");

            // Compute the ConnectionString (using the OLEDB v12.0 driver compatible with ACCDB and MDB files)
            fileName = Path.GetFullPath(fileName);
            
            string connString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=\"{0}\"; Jet OLEDB:Database Password={1};", fileName, password);

            // Opening the Access connection
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();

                // Getting all user tables present in the Access file (Msys* tables are system thus useless for us)
                DataTable dt = conn.GetSchema("Tables");
                List<string> tablesName = dt.AsEnumerable().Select(dr => dr.Field<string>("TABLE_NAME")).Where(dr => !dr.StartsWith("MSys")).ToList();

                // Getting the data for every user tables
                foreach (string tableName in tablesName)
                {
                    using (OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}]", tableName), conn))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            // Saving all tables in our result DataSet.
                            DataTable buf = new DataTable("[" + tableName + "]");
                            adapter.Fill(buf);
                            result.Tables.Add(buf);
                        } // adapter
                    } // cmd
                } // tableName
            } // conn

            // Return the filled DataSet
            return result;
        }
    }
}