using Bsnl.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JmGrove.BOL
{
    class CommonFunction
    {
        #region Data Members

        public int id { get; set; }
        public string DesignationType { get; set; }
        public string DesignationCode { get; set; }
        #endregion

        public static DataTable GetDesignationType()
        {
            database db = new database();
            db.AddParameter("@QryType", "S");
            return db.GetDataTable("DesigCode");
        }

        public static object GetDesignationTypeID(string DesignCode)
        {
            database db = new database();
            db.AddParameter("@DesignationCode", DesignCode);
            db.AddParameter("@QryType", "G");
            return db.GetDataValue("DesigCode");
        }
    }
}
