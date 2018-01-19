using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsBank
{
    class DebitCredit
    {
        private frmUsersWindow.TransactionType  m_TranType;
        private Guid m_UserGuid;

        public DebitCredit(Guid userGuid, frmUsersWindow.TransactionType tranType)
        {
            m_TranType = tranType;
            m_UserGuid = userGuid;
    

         //   if (tranType == frmUsersWindow.TransactionType.Credit){ txtAmount.ForeColor = Color.Green; }
         //   else { txtAmount.ForeColor = Color.Red; }
            
         //   this.Text = tranType.ToString();
        }

        public bool CreditApply(decimal amount, string description)
        {
            //if (FindBlankTextboxes()) { return; }
            SQL cmd = new SQL();
            SchemaTransactions tran = new SchemaTransactions();
            
            //description = txtDescription.Text;
            
            cmd.INSERT(tran.TableName, SchemaTransactions.fields.guid.ToString() + "," + SchemaTransactions.fields.transactionType.ToString() + "," + 
                SchemaTransactions.fields.amount.ToString() + "," + SchemaTransactions.fields.description.ToString() + "," + SchemaTransactions.fields.userguid.ToString() + "," +
                SchemaTransactions.fields.date.ToString(), 
                string.Format("{0},{1},{2},'{3}','{4}',{5}", SQL.NEWID, (byte)m_TranType, amount, description, m_UserGuid.ToString(), SQL.GETDATE));

            if (!cmd.Execute()) { return false; }
            return true;
        }
    }
}
