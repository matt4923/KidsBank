using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace KidsBank
{
    public partial class frmLogin : Form
    {
        private string m_connString = "Data Source=Kids.sdf;password=4923;Persist Security Info=False;";
        public frmLogin()
        {
            InitializeComponent();
            TestForDb();
            txtUser.Text = "admin";
            txtPassword.Text = "4923";
        }

        private void TestForDb()
        {
            SqlCeConnection sc = new SqlCeConnection(m_connString);
            try
            {
                sc.Open();
                sc.Close();
            }
            catch (SqlCeException ex)
            {
                //db doesn't exist, create it
                SqlCeEngine en = new SqlCeEngine(m_connString);
                en.CreateDatabase();
                DbBuilder dbBldr = new DbBuilder();
                dbBldr.BuildNewDb();
                dbBldr.AddAdminUser();
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtUser.Text;
            string password = txtPassword.Text;
            DataRow userRecord = GetUserData(name);
            if(userRecord[0].Equals(Guid.Empty))
            {
                ErrorOnUserCredentials();
                return;
            }

            string passRetrieved = (string)userRecord[KidsBank.SchemaUsers.fields.password.ToString()];
            bool admin = false;

            if (name == "admin" && password == "4923") 
            {
                admin = true;
            }
            
            if (password == passRetrieved)
            {
                frmUsersWindow UsersWindow = new frmUsersWindow(userRecord, admin);
                UsersWindow.Show();
            }
            else 
            {
                ErrorOnUserCredentials();
            }
            this.Visible = false;

        }

        private void ErrorOnUserCredentials()
        {
            MessageBox.Show("Incorrect username or password. Please try again.");
            txtUser.Text = "";
            txtPassword.Text = "";
            txtUser.Focus();    
        }

        private DataRow GetUserData(string name)
        {
            SchemaUsers schUsers = new SchemaUsers();
            SQL cmd = new SQL();
            cmd.SELECT(SQL.ALLFIELDS, schUsers.TableName);
            cmd.WHERE(string.Format("{0}='{1}'", KidsBank.SchemaUsers.fields.name.ToString(), name));
            DataTable dt = cmd.ExecuteWithRead();
            DataRow dr;
            try
            {
                dr = dt.Rows[0];
            }
            catch (IndexOutOfRangeException err) 
            { 
                //no user with specified name exists, return empty row
                dr = dt.NewRow();
                dr[KidsBank.SchemaUsers.fields.guid.ToString()] = Guid.Empty;
            }
            
            return dr;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
