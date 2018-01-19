using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KidsBank
{
    class SchemaUsers
    {
        public string TableName = "Users";
        public string fieldsAndType = "guid uniqueidentifier primary key, name nvarchar(100) not null, boy_or_girl tinyint, password nvarchar(20), balance money not null";
        
        public enum fields
        {
            guid,  //uniqueidentifier, primary key
            name,  //nvarchar 100, allow nulls = false
            boy_or_girl, //tinyint, allow nulls = true
            password, //nvarchar 20, allow nulls = true
            balance  //money 19, allow nulls = false
        }
    }

    class UserMain : SchemaUsers 
    {
        private Guid m_Guid;
        private string m_Name;
        private byte m_Sex;
        private decimal m_Balance;

        public UserMain(DataRow dr)
        {
            m_Guid = (Guid)dr[fields.guid.ToString()];
            m_Name = (string)dr[fields.name.ToString()];
            m_Balance = (decimal)dr[fields.balance.ToString()];
            m_Sex = (byte)dr[fields.boy_or_girl.ToString()];
        }

        public Guid Guid
        {
            get { return m_Guid; }
        }

        public string Name
        {
            get { return m_Name; }
        }

        public byte Sex
        {
            get { return m_Sex; }
        }

        public decimal Balance
        {
            set { m_Balance = value; }
            get { return m_Balance; }
        }
    }
}
