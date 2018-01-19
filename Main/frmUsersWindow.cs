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
    public partial class frmUsersWindow : Form
    {
        private UserMain m_User;
        private bool m_DescriptionTitle;
        private bool m_IsAdmin;

        public enum TransactionType
        {
            Credit,
            Debit
        }

        public frmUsersWindow(DataRow userRec, bool admin)
        {
            InitializeComponent();
            m_User = new UserMain(userRec);
            m_IsAdmin = admin;

            this.Text = string.Format("Account Management | {0}", m_User.Name); 
            lblStatus.Text = string.Format("Welcome {0}!", m_User.Name.ToUpper());
            lblBalance.Text = "$" + m_User.Balance.ToString("F2");
            ClearDescriptionText();

            StartClockTimer();
            UpdateUserTransactionGrid();
            
            tabAdmin.Enabled = m_IsAdmin;
            if (m_IsAdmin) {
                toolCreateDb.Enabled = true;
                toolNew.Enabled = true;
                UpdateFullTransactionGrid(); 
            }
            else { tabMainControl.TabPages.Remove(tabAdmin); }
        }

        private void UpdateFullTransactionGrid()
        {
            SQL cmd = new SQL();
            SchemaTransactions schTran = new SchemaTransactions();
            cmd.SELECT("*", schTran.TableName);
            
        }

        private void ClearDescriptionText()
        {
            txtDescription.ForeColor = Color.Silver;
            txtDescription.Text = "New Transaction Description...";
            m_DescriptionTitle = true;
        }

        private void StartClockTimer()
        {
            Timer t = ClockTimer;
            t.Interval = 1000;
            t.Enabled = true;
            t.Start();
        }

        public void UpdateUserTransactionGrid()
        {
            SQL cmd = new SQL();
            SchemaTransactions schTran = new SchemaTransactions();

            cmd.SELECT(SchemaTransactions.fields.amount.ToString() + "," +
                SchemaTransactions.fields.description.ToString() + "," + SchemaTransactions.fields.date.ToString(), schTran.TableName);
            cmd.WHERE(string.Format("{0}='{1}'", SchemaTransactions.fields.userguid.ToString(), m_User.Guid.ToString()));
            cmd.ORDERBY(SchemaTransactions.fields.date.ToString() + SQL.DESC);
            DataTable dt = cmd.ExecuteWithRead();
 
            gridTransactions.DataSource = dt;
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newUser = new frmNewUser();
            newUser.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeForm(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        private TransactionType m_Type;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DebitCreditInitialize(m_Type);
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        private void DebitCreditInitialize(TransactionType tranType)
        {
            if (!FindBlankTextboxes())
            {
                DebitCredit tran = new DebitCredit(m_User.Guid, tranType);
                decimal amount =  decimal.Parse(txtDebitCredit.Text.Replace("$", ""));
                if (tran.CreditApply(amount, txtDescription.Text))
                {
                    
                    UpdateUserTransactionGrid();
                    //update balance
                    decimal newBal = m_User.Balance + amount;
                    UpdateUserBalance(newBal);
                    
                    //clear fields
                    ClearDescriptionText();
                    //txtDebitCredit.Text = "";
                    DoUpdateTypeBox();
                }
            }
        }

        private void UpdateUserBalance(decimal newBal)
        {
            SQL cmd = new SQL();

            cmd.UPDATE(m_User.TableName, string.Format("{0}={1}", SchemaUsers.fields.balance.ToString(), newBal));
            cmd.WHERE(string.Format("{0}='{1}'", SchemaUsers.fields.guid.ToString(), m_User.Guid));
            if (cmd.Execute()) { 
                lblBalance.Text = "$" + newBal.ToString("F2");
                m_User.Balance = newBal;
            }
        }

        private void cbxDebitCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoUpdateTypeBox();
        }

        private void DoUpdateTypeBox()
        {
            if (cbxDebitCredit.SelectedIndex == (int)TransactionType.Debit)
            {
                m_Type = TransactionType.Credit;
                txtDebitCredit.ForeColor = Color.Green;
                txtDebitCredit.Text = "+$0.00";
            }
            else
            {
                m_Type = TransactionType.Debit;
                txtDebitCredit.ForeColor = Color.Red;
                txtDebitCredit.Text = "-$0.00";
            }
        }

        private void EnterDescriptionField(object sender, EventArgs e)
        {
            if(m_DescriptionTitle)
            {
                //clear out and change text color to black
                txtDescription.Text = "";
                txtDescription.ForeColor = Color.Black;
                m_DescriptionTitle = false;
            }
        }

        private bool FindBlankTextboxes()
        {
            if (m_DescriptionTitle || txtDebitCredit.Text == string.Empty || cbxDebitCredit.SelectedIndex < 0)
            {
                MessageBox.Show("Cannot leave the Amount or Description Fields blank");
                return true;
            }
            return false;
        }

        private void CheckDescriptionForBlank(object sender, EventArgs e)
        {
            if (txtDescription.Text.Trim() == "") { ClearDescriptionText(); }
        }
    }
}
