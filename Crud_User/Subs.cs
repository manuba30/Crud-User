using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_User
{
    public partial class Subs : Form
    {
        public Subs()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            SaveUserData();
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("there are empty camps, please fullfill all of them", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AllUsercs sub = new AllUsercs();
                sub.ShowDialog();
                this.Hide();
            }
        }

        public void SaveUserData()
        {
            Register register = new Register();

            register.Username = txtUser.Text;
            register.Password = txtPass.Text;

            register.CreateUser(register);
        }

        private void Subs_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
