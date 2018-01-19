using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace KidsBank
{
    class SQL
    {
        SqlCeConnection sc = new SqlCeConnection("Data Source=Kids.sdf;password=4923;Persist Security Info=False;");
        public const string NEWID = "NEWID()";
        public const string ALLFIELDS = "*";
        public const string GETDATE = "GETDATE()";
        public const string DESC = " DESC ";
        private string m_query;

        void sql()
        {
            m_query = string.Empty;
        }

        public void SELECT(string fields, string table)
        {
            m_query += string.Format("SELECT {0} FROM {1}", fields, table);
        }

        public void INSERT(string table, string columns, string values)
        {
            m_query = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", table, columns, values);
        }

        public void UPDATE(string table, string set)
        {
            m_query = string.Format("UPDATE {0} SET {1}", table, set);
        }

        public void WHERE(string str)
        {
            m_query += string.Format(" WHERE {0}", str);
        }

        public void ORDERBY(string ordrStr)
        {
            m_query += string.Format(" ORDER BY {0}", ordrStr);
        }

        internal bool Execute()
        {
            m_query += ";";
            sc.Open();
            SqlCeCommand cmd = new SqlCeCommand (m_query, sc);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Writing to the Database Failed:{0}\r\n", ex.ToString()));
                return false;
            }
            finally 
            {
                sc.Close();            
                m_query = string.Empty; 
            }
            return true;
        }

        internal DataTable ExecuteWithRead()
        {
            m_query += ";";
            DataTable dt = new DataTable();
            sc.Open();
            SqlCeCommand cmd = new SqlCeCommand(m_query, sc);
            
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
            
            da.Fill(dt);
            sc.Close();
            m_query = string.Empty;
            return dt;
        }

        internal void Create_Table(string tableName, string fields)
        {
            m_query += string.Format("Create Table {0}({1})", tableName, fields);
        }
    }
}
