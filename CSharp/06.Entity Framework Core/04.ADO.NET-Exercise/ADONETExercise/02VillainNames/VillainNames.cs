using Microsoft.Data.SqlClient;
using System;

namespace _02VillainNames
{
    internal class VillainNames
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createQuery = "SELECT v.Name As Name, COUNT(mv.VillainId) As MinionsCount " +
                    "FROM Villains v " +
                    "JOIN MinionsVillains mv ON mv.VillainId = v.Id " +
                    "GROUP BY v.Id, v.Name " +
                    "HAVING COUNT(mv.MinionId) > 3 " +
                    "ORDER BY MinionsCount DESC";
                var command = new SqlCommand(createQuery, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                    }
                }
            }
        }
    }
}
