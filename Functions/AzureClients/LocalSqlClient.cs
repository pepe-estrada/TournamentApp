using System;
using Microsoft.Data.SqlClient;

namespace TournamentApp.Functions.AzureClients
{
    public class LocalSqlClient
    {
        private readonly string _connectionString;

        public static void SendInformation(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Leads] (ID, LastName, FirstName, DOB, Belt, Email, Phone) VALUES (@LastName, @FirstName, @DOB, @Belt, @Email, @Phone)", connection))
                {
                    command.Parameters.AddWithValue("@LastName", "Doe");
                    command.Parameters.AddWithValue("@FirstName", "John");
                    command.Parameters.AddWithValue("@DOB", "01/01/2000");
                    command.Parameters.AddWithValue("@Belt", "White");
                    command.Parameters.AddWithValue("@Email", "john.doe@gmail.com");
                    command.Parameters.AddWithValue("@Phone", "123-456-7890");
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
