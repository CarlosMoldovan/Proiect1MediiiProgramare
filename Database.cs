using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

public class Database
{
    private const string ConnectionString = "Data Source=MyDatabase.db;Version=3;";

    public void CreateDatabase()
    {
        if (!File.Exists("MyDatabase.db"))
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string createTableQuery = "CREATE TABLE IF NOT EXISTS MyTable (ID INTEGER PRIMARY KEY AUTOINCREMENT, Denumire CuvântCheie);";
                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Verificare structură tabel după creare
                string checkTableStructureQuery = "PRAGMA table_info(MyTable);";
                using (SQLiteCommand command = new SQLiteCommand(checkTableStructureQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["name"].ToString();
                            Console.WriteLine("Column Name: " + columnName);
                        }
                    }
                }

                connection.Close();
            }
        }
    }


    public void InsertData(string CuvântCheie)
    {
        using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string insertDataQuery = "INSERT INTO MyTable (CuvântCheie) VALUES (@CuvântCheie);";
            using (SQLiteCommand command = new SQLiteCommand(insertDataQuery, connection))
            {
                command.Parameters.AddWithValue("@CuvântCheie", CuvântCheie);
                command.ExecuteNonQuery();
            }
        }
    }

    public DataTable GetData()
    {
        DataTable dataTable = new DataTable();

        using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string getDataQuery = "SELECT * FROM MyTable;";
            using (SQLiteCommand command = new SQLiteCommand(getDataQuery, connection))
            {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
        }

        return dataTable;
    }

     

    public void DeleteData(int id)
    {
        using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string deleteDataQuery = "DELETE FROM MyTable WHERE ID = @ID;";
            using (SQLiteCommand command = new SQLiteCommand(deleteDataQuery, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }
        }
    }

    public void Cautare(string id)
    {
        using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string cautare = "SELECT * FROM MyTable WHERE CuvântCheie= @ID;";
            using (SQLiteCommand command = new SQLiteCommand(cautare, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}, CuvântCheie: {reader["CuvântCheie"]}");
                    }
                }
            }
        }
    }

}


