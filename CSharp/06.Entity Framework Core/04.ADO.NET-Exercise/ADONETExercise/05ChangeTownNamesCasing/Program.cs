using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _05ChangeTownNamesCasing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            var connectionString = "Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    var command = new SqlCommand("UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", connection);
                    command.Parameters.AddWithValue("countryName", countryName);
                    var rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"{rowsAffected} town names were affected.");
                        command.CommandText = "SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName";
                        var reader = command.ExecuteReader();
                        var towns = new List<String>();
                        while (reader.Read())
                        {
                            towns.Add(reader["Name"].ToString());
                        }

                        Console.WriteLine($"[{string.Join(", ", towns)}]");
                    }
                    else
                    {
                        Console.WriteLine("No town names were affected.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }  
        }
    }
}
