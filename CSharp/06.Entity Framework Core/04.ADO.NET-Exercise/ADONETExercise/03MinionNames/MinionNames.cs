using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _03MinionNames
{
    internal class MinionNames
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer id:");
            int id = int.Parse(Console.ReadLine());

            var connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    var output = new List<string>();

                    connection.Open();

                    string createQuery = "SELECT Name FROM Villains WHERE Id = @Id";
                    var command = new SqlCommand(createQuery, connection);
                    command.Parameters.AddWithValue("id", id);
                    
                    var name = command.ExecuteScalar();
                    if (name == null)
                    {
                        output.Add($"No villain with ID {id} exists in the database.");
                    }
                    else
                    {
                        output.Add($"Villain: {name}");
                        command.Parameters.Clear();
                        command.CommandText = "SELECT m.Name AS MinionName, m.Age AS MinionAges, ROW_NUMBER() OVER (ORDER BY mv.VillainId) As RowNumber " +
                            "FROM MinionsVillains mv " +
                            "LEFT JOIN Minions m ON m.Id = mv.MinionId " +
                            "WHERE mv.VillainId = @Id " +
                            "ORDER BY m.Name";
                        command.Parameters.AddWithValue("id", id);
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                output.Add($"{reader["RowNumber"]}. {reader["MinionName"]} {reader["MinionAges"]}");
                            }
                        }
                        else
                        {
                            output.Add("(no minions)");
                        }

                        reader.Close();
                    }

                    Console.WriteLine(string.Join(Environment.NewLine, output));

                }
                catch (SqlException ex)
                { 
                    Console.WriteLine(ex.Message); 
                }
            }
        }
    }
}
