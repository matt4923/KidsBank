using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsBank
{
    class DbBuilder
    {

        private void BuildUsersTable()
        {
            SQL cmd = new SQL();
            SchemaUsers schUsers = new SchemaUsers();
            cmd.Create_Table(schUsers.TableName, schUsers.fieldsAndType);
            cmd.Execute();
        }

        private void BuildTransactionTable()
        {
            SQL cmd = new SQL();
            SchemaTransactions schTransactions = new SchemaTransactions();
            cmd.Create_Table(schTransactions.TableName, schTransactions.fieldsAndType);
            cmd.Execute();
        }

        internal void BuildNewDb()
        {
            BuildUsersTable();
            BuildTransactionTable();
        }

        internal void AddAdminUser()
        {
            SQL sql = new SQL();
            SchemaUsers schUsers = new SchemaUsers();

            sql.INSERT(schUsers.TableName, KidsBank.SchemaUsers.fields.guid.ToString() + "," + KidsBank.SchemaUsers.fields.name.ToString() + "," +
                KidsBank.SchemaUsers.fields.boy_or_girl.ToString() + "," + KidsBank.SchemaUsers.fields.password.ToString() + "," + KidsBank.SchemaUsers.fields.balance.ToString(), 
                string.Format("{2},'{0}',{1},'{3}',{4}", "admin", 0, SQL.NEWID, "4923", 100));
            sql.Execute();
        }
    }
}
