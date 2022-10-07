using Microsoft.Data.SqlClient;
using System.Data;

namespace MyLogin.Data
{
    public class CreateClass
    {
        private string username;
        private string password;
        private string email;

    public CreateClass(string username, string password, string email)
    {
        this.username = username;
        this.password = password;
        this.email = email;
    }

    public void CreateSQL()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=LoginDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();

            SqlCommand command = new SqlCommand(
            "INSERT INTO brugere ([Name] , Email,  [Password]) Values (@CreateUser,@CreateEmail,@CreatePassword)", conn);
            command.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = username;
            command.Parameters.Add("@CreateEmail", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@CreatePassword", SqlDbType.NVarChar).Value = password;
            command.ExecuteNonQuery();
        }
    }
}
