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
            try{
                // TODO: Implement your logic here
                string conn = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
                if(String.IsNullOrEmpty(conn)){
                    return "Connection string is empty";
                }
                SqlConnection connection = new SqlConnection(conn);
                
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.leads", connection))
                {
                    StringBuilder sb = new StringBuilder();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sb.AppendLine(String.Format("{0}, {1}, {2}, {3}, {4}", reader["Id"], reader["FirstName"],reader["LastName"],reader["Email"],reader["Phone"]));
                        }
                    }
                    connection.Close();
                    return sb.ToString();
                }
            }
            catch (Exception e){
                return e.Message;
            }
        }
    }
}
