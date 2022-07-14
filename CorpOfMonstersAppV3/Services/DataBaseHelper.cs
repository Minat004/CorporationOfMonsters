using System.Collections.Generic;
using System.Data.SQLite;
using CorpOfMonstersAppV3.Models;

namespace CorpOfMonstersAppV3.Services;

public class DataBaseHelper
{
    public DataBaseHelper(string dataSource)
    {
        Connection = new SQLiteConnection(dataSource);
        Connection.Open();

        Command = new SQLiteCommand(Connection);
        CreateTable();
    }
    
    private void CreateTable()
    {
        Command.CommandText = $"CREATE TABLE IF NOT EXISTS workers(" + 
                              $"id INTEGER PRIMARY KEY AUTOINCREMENT," +
                              $"first_name TEXT," +
                              $"last_name TEXT," +
                              $"contract TEXT," +
                              $"over_hours INTEGER DEFAULT 0" +
                              $")";

        Command.ExecuteNonQuery();
    }

    public void InsertData(string firstName, string lastName, string contract, int overHours = 0)
    {
        Command.CommandText = $"INSERT INTO workers(first_name, last_name, contract, over_hours) " +
                              $"VALUES(" +
                              $"'{firstName}', " +
                              $"'{lastName}', " +
                              $"'{contract}', " +
                              $"{overHours}" +
                              $")";

        Command.ExecuteNonQuery();
    }

    public IEnumerable<Employee> ReadData()
    {
        Command.CommandText = "SELECT * FROM workers";
        var dataReader = Command.ExecuteReader();

        var listEmployee = new List<Employee>();

        while (dataReader.Read())
        {
            listEmployee.Add(new Employee(dataReader.GetString(1), dataReader.GetString(2)));
        }
        
        return listEmployee;
    }

    private SQLiteConnection Connection { get; }
    
    private SQLiteCommand Command { get; }
    
}