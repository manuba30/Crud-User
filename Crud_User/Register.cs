using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_User
{
    internal class Register
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        string connectionString = "Data Source=DESKTOP-COKF0ND\\MYSQL;Initial Catalog=teste;Integrated Security=True;Encrypt=False;";

        public void CreateUser(Register register)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("CreateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Verifica se os valores não são nulos antes de passá-los como parâmetros
                if (!string.IsNullOrEmpty(register.Username) && !string.IsNullOrEmpty(register.Password))
                {
                    cmd.Parameters.Add(new SqlParameter("@User", register.Username));
                    cmd.Parameters.Add(new SqlParameter("@Password", register.Password));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Usuário criado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Nome de usuário e senha não podem ser nulos ou vazios.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar usuário: " + ex.Message);
            }

        }
        public List<Register> GetAll()
        {
            List<Register> users = new List<Register>();

            SqlConnection con = new SqlConnection(connectionString);

            string selectSQL = "Select UserId,Username,Password FROM GetAllUsers";

            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {

                    Register register = new Register();
                    register.UserId = Convert.ToInt32(dr["UserId"]);
                    register.Username = dr["Username"].ToString();
                    register.Password = dr["Password"].ToString();
                    users.Add(register);


                }
            }
            return users;
        }
        public void EditUser(Register register)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@UserId", register.UserId));
                    cmd.Parameters.Add(new SqlParameter("@Username", register.Username));
                    cmd.Parameters.Add(new SqlParameter("@Password", register.Password));
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public Register GetUserData(int UserId)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string selectSQL = "select UserId, Username, Password from GetAllUsers where UserId = " + UserId;

            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);

            SqlDataReader dr = cmd.ExecuteReader();

            Register register = new Register();
            if (dr != null)
            {
                while (dr.Read())
                {
                    register.UserId = Convert.ToInt32(dr["UserId"]);
                    register.Username = dr["Username"].ToString();
                    register.Password = dr["Password"].ToString();

                }
            }
                return register;
        }

        public void DeleteSpecificUser(int UserId)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("DeleteUser",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserId",UserId));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();    
        }

    }
}

