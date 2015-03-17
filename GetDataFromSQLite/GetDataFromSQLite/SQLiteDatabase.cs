using System;
using System.Data;
using System.Data.SQLite;

public class SQLiteDatabase
{
    String dbConnection;

    /// <summary>
    ///     Single Param Constructor for specifying the DB file.
    /// </summary>
    /// <param name="inputFile">The File containing the DB</param>
    public SQLiteDatabase(String inputFile)
    {
        dbConnection = String.Format("Data Source={0}", inputFile);
    }

    /// <summary>
    ///     Allows the programmer to run a query against the Database.
    /// </summary>
    /// <param name="sql">The SQL to run</param>
    /// <returns>A DataTable containing the result set.</returns>
    public DataTable GetDataTable(string sql)
    {
        DataTable dt = new DataTable();
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand myCommand = new SQLiteCommand(cnn);
            myCommand.CommandText = sql;
            SQLiteDataReader reader = myCommand.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return dt;
    }
}

