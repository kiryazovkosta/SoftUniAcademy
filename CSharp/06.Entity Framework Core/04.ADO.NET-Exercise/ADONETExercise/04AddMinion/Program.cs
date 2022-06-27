using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _04AddMinion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var minion = Console.ReadLine().Split(": ")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var villain = Console.ReadLine().Split(": ")[1];

            var townId = -1;
            var villainId = -1;
            var minionId = -1;

            var connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction= connection.BeginTransaction();

                try
                { 
                    var command = new SqlCommand("SELECT Id FROM Towns WHERE Name = @townName", connection);
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("townName", minion[2]);
                    var result = command.ExecuteScalar();
                    if (result == null)
                    {
                        command.CommandText = "INSERT INTO Towns (Name) VALUES (@townName)";
                        if(command.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine($"Town {minion[2]} was added to the database.");
                        }

                        command.CommandText = "SELECT Id FROM Towns WHERE Name = @townName";
                        result = command.ExecuteScalar();
                    }
                    townId = Convert.ToInt32(result);

                    command.Parameters.Clear();
                    command.CommandText = "SELECT Id FROM Villains WHERE Name = @Name";
                    command.Parameters.AddWithValue("Name", villain);
                    result = command.ExecuteScalar();
                    if (result == null)
                    {
                        command.CommandText = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@Name, 4)";
                        if(command.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine($"Villain {villain} was added to the database.");
                        }

                        command.CommandText = "SELECT Id FROM Villains WHERE Name = @Name";
                        result = command.ExecuteScalar();
                    }
                    villainId = Convert.ToInt32(result);

                    command.Parameters.Clear();
                    command.CommandText = "INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";
                    command.Parameters.AddWithValue("nam", minion[0]);
                    command.Parameters.AddWithValue("age", int.Parse(minion[1]));
                    command.Parameters.AddWithValue("townId", townId);
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = "SELECT Id FROM Minions WHERE Name = @Name";
                    command.Parameters.AddWithValue("Name", minion[0]);
                    minionId = Convert.ToInt32(command.ExecuteScalar());

                    command.Parameters.Clear();
                    command.CommandText = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
                    command.Parameters.AddWithValue("villainId", villainId);
                    command.Parameters.AddWithValue("minionId", minionId);
                    if(command.ExecuteNonQuery()> 0)
                    {
                        Console.WriteLine($"Successfully added {minion[0]} to be minion of {villain}.");
                    }

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
            }
        }
    }
}
