using Microsoft.Data.SqlClient;
using System.Data;

namespace MyLogin.Data
{
    public class LoginClass
    {
        private string username;
        private string password;

    public LoginClass(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public void SQL()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=LoginDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();

                SqlCommand command = new SqlCommand(
            //    "Select LoginUser from LoginDB", conn);
               "Select * FROM Brugere Where [Name] =@userlogin  AND [Password] =@passwordlogin", conn);
            command.Parameters.Add("@userlogin", SqlDbType.NVarChar).Value = username;
            command.Parameters.Add("@passwordlogin", SqlDbType.NVarChar).Value = password;
            //// int result = command.ExecuteNonQuery();
            //using (SqlDataReader reader = command.ExecuteReader())
            //{
            // while (reader.Read())
            //   {
            //       Console.WriteLine(String.Format("{0}", reader["LoginUser"]));
            //   }
            //}

            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            if (dataTable.Rows.Count <= 0)
            {
                Console.WriteLine("Username or Password does not exist");
            }

            else
            {
                Console.WriteLine($"Successfully logged in with {username}");
            }

            conn.Close();
        }

    }
}
