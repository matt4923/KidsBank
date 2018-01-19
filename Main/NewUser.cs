using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KidsBank
{
    public partial class frmNewUser : Form
    {
        public frmNewUser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if(!PasswordCheck(txtPassword.Text, txtConfPassword.Text)){ return; }
            string bal = txtBalance.Text.Replace("$","");

            if (NewUserInDb(txtName.Text, radBoy.Checked, radGirl.Checked, txtPassword.Text, decimal.Parse(bal)))
            {
                this.Close();
            }
            else
            {
                txtName.Focus();
            }
            
        }

        private bool NewUserInDb(string name, bool radBoy, bool radGirl, string password, decimal balance)
        {
            byte sex = 0;
            if (radBoy) { sex = 1; }
            else if (radGirl) { sex = 2; }

            SQL sql = new SQL();
            SchemaUsers schUsers = new SchemaUsers();

            sql.INSERT(schUsers.TableName, KidsBank.SchemaUsers.fields.guid.ToString() + "," + KidsBank.SchemaUsers.fields.name.ToString() + "," +
                KidsBank.SchemaUsers.fields.boy_or_girl.ToString() + "," + KidsBank.SchemaUsers.fields.password.ToString() + "," + KidsBank.SchemaUsers.fields.balance.ToString(), 
                string.Format("{2},'{0}',{1},'{3}',{4}", name, sex, SQL.NEWID, password, balance));
            if (sql.Execute())
            {
                return true;
            }
            else { return false; }
        }

        private void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            if (!PasswordCheck(txtPassword.Text, txtConfPassword.Text)) { return; }
            string bal = txtBalance.Text.Replace("$", "");
            if (NewUserInDb(txtName.Text, radBoy.Checked, radGirl.Checked, txtPassword.Text, decimal.Parse(bal)))
            {
                ClearFields();
                txtName.Focus();
            }
            else
            {
                txtName.Focus();
            }
            
        }

        private bool PasswordCheck(string pass1, string pass2)
        {
            if (pass1 != pass2)
            {
                MessageBox.Show("Passwords do not match.  Please try again.");
                txtPassword.Text = string.Empty;
                txtConfPassword.Text = string.Empty;
                txtPassword.Focus();
                return false;
            }
            else return true;
        }

        private void ClearFields()
        {
            txtPassword.Text = string.Empty;
            txtName.Text = string.Empty;
            txtConfPassword.Text = string.Empty;
            radBoy.Checked = false;
            radGirl.Checked = false;
            txtBalance.Text = string.Empty;
        }
     } //end class frmNewUser
} //end namespace main
