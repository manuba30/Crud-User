using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_User
{
    public partial class btnCreate : Form
    {
        public btnCreate()
        {
            InitializeComponent();
        }
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-COKF0ND\MYSQL;Initial Catalog=teste;Integrated Security=True;Encrypt=False;");

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label1_Click_1(object sender, EventArgs e)
            {

            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }

            private void btn_clear_Click(object sender, EventArgs e)
            {
                txtUser.Clear();
                txtPass.Clear();

                txtUser.Clear();
            }

            private void btn_exit_Click(object sender, EventArgs e)
            {
                DialogResult res;
                res = MessageBox.Show("are you sure you want to quit", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    this.Show();
                }
            }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = txtUser.Text;
            user_password = txtPass.Text;

            try
            {
                String query = "SELECT * FROM Login WHERE username = @Username AND password = @Password";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.Parameters.AddWithValue("@Username", username);
                sda.SelectCommand.Parameters.AddWithValue("@Password", user_password);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    // Sucesso ao fazer login
                    // Página que será carregada
                    AllUsercs form2 = new AllUsercs();
                    form2.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Clear();
                    txtPass.Clear();
                    
                    txtUser.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Subs subs = new Subs();
            subs.ShowDialog();
            this.Close();
        }
    }
}

