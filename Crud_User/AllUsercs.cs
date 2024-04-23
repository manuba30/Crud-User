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
    public partial class AllUsercs : Form
    {
        public AllUsercs()
        {
            InitializeComponent();
            FillGridView();
        }
        void FillGridView()
        {
            List<Register> users = new List<Register>();
            Register register = new Register();

            users = register.GetAll();

            dataGridViewUsers.DataSource = users;
        }

        private void AllUsercs_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            btnCreate form1 = new btnCreate();
            form1.ShowDialog();
            this.Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditUsers();
            this.Close();
        }

        void EditUsers()
        {
            int UserId;

            UserId = (int)dataGridViewUsers.CurrentRow.Cells[0].Value;

            EditUser formEdit = new EditUser(UserId);
            formEdit.ShowDialog();
        }

        private void AllUsercs_Activated(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Subs subs = new Subs(); 
            subs.ShowDialog();
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        void DeleteUser()
        {
            int UserId;

            UserId = (int)dataGridViewUsers.CurrentRow.Cells[0].Value;

            Register register = new Register(); 
            register.DeleteSpecificUser(UserId);
            FillGridView(); 
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
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
    }
}
