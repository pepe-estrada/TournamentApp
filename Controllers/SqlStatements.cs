using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Controllers
{
    public class SqlStatementsController : ControllerBase
    {
        public static String GetSummary()
        {
            // TODO: Implement your logic here
            SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING"));
            connection.Open();
            using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.Tournaments", connection))
            {
                StringBuilder sb = new StringBuilder();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sb.AppendLine(String.Format("{0}, {1}", reader["Id"], reader["Name"]));
                    }
                }
                connection.Close();
                return sb.ToString();
            }
        }
    }
}
