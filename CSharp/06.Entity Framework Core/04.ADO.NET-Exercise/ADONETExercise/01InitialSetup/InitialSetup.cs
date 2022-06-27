using Microsoft.Data.SqlClient;
using System;

namespace _01InitialSetup
{
    internal class InitialSetup
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Database=master;Integrated Security=true;TrustServerCertificate=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createQuery = "CREATE DATABASE MinionsDB";
                var command = new SqlCommand(createQuery, connection);
                command.ExecuteNonQuery();
                Console.WriteLine($"DataBase [MinionsDB] is created successfully");
            }

            connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string createQuery = "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))";
                    var command = new SqlCommand(createQuery, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Table [Countries] is created successfully");

                    command.CommandText = "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Table [Towns] is created successfully");

                    command.CommandText = "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))";
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Table [Minions] is created successfully");

                    command.CommandText = "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Table [EvilnessFactors] is created successfully");

                    command.CommandText = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Table [Villains] is created successfully");

                    command.CommandText = "CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id), VillainId INT FOREIGN KEY REFERENCES Villains(Id), CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))";
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Table [MinionsVillains] is created successfully");


                    command.CommandText = "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";
                    var rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} records ware successfully inserted into table [Countries] ");

                    command.CommandText = "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";
                    rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} records ware successfully inserted into table [Towns] ");

                    command.CommandText = "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)";
                    rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} records ware successfully inserted into table [Minions] ");

                    command.CommandText = "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";
                    rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} records ware successfully inserted into table [EvilnessFactors] ");

                    command.CommandText = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)";
                    rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} records ware successfully inserted into table [Villains] ");

                    command.CommandText = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";
                    rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} records ware successfully inserted into table [MinionsVillains] ");

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
