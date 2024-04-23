using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Crud_User
{
    public partial class EditUser : Form
    {
        int SelectedUserId; 
        public EditUser(int UserId)
        {
            InitializeComponent();
            SelectedUserId = UserId;
            GetUserData();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {

        }
        void GetUserData()
        {
            Register register = new Register();
            register = register.GetUserData(SelectedUserId);

            txtUser.Text = register.Username;
            txtPass.Text = register.Password;
        }

        void EditUserData()
        {
            Register register = new Register();

            register.UserId = SelectedUserId;
            register.Username = txtUser.Text;
            register.Password = txtPass.Text;

            register.EditUser(register);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditUserData();
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
