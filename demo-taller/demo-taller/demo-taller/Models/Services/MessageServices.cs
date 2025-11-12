using demo_taller.Models.Entities;
using Microsoft.Data.SqlClient;

namespace demo_taller.Models.Services
{
    public class MessageServices
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public MessageServices(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public int Post(Message message)
        {
            int result = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("sp_insertMessageToInbox", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", message.Name);
                    sqlCommand.Parameters.AddWithValue("@Email", message.Email);
                    sqlCommand.Parameters.AddWithValue("@Subject", message.Subject);
                    sqlCommand.Parameters.AddWithValue("@Message", message.Content);

                    result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }catch (SqlException)
                {
                    throw;
                }
            }
            return result;
        }
        
    }
}
