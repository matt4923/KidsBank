using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsBank
{
    class SchemaTransactions
    {
        public string TableName = "Transactions";
        public string fieldsAndType = "guid uniqueidentifier primary key, transactionType tinyint not null, amount money not null, " + 
            " description nvarchar(50) not null, userguid uniqueidentifier not null, date datetime not null";
        
        public enum fields
        {
            guid,  //uniqueidentifier, primary key
            transactionType,  //tinyint, allow nulls = false
            amount, //money, allow nulls = false
            description, //nvarchar 50, allow nulls = false
            userguid,  //uniqueIdentifier, allow nulls = false
            date //datetime
        }

    }
}
