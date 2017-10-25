using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Bsnl.DAL;

namespace Bsnl.BOL
{
    class Desig
    {

        #region Data Members

        public int DesigId { get; set; }
        public string DesigNm { get; set; }
        public int DesigTypeID { get; set; }
        #endregion


        #region Shared Methods

        public static DataTable GetStates()
        {
            database db = new database();
            db.AddParameter("@QryType", "S");
            return db.GetDataTable("DesigProc");
        }

        public static string GetMaxStateId()
        {
            database db = new database();
            db.AddParameter("@QryType", "M");
            return db.GetMaxId("DesigProc").ToString();
        }

        public static void Save(Desig st, string QryType)
        {
            database db = new database();
            db.AddParameter("@DesigId", st.DesigId);
            db.AddParameter("@DesigNm", st.DesigNm);
            db.AddParameter("@DesigTypeID", st.DesigTypeID);
            db.AddParameter("@QryType", QryType);
            db.ExecuteSP("DesigProc");
        }

        public static void Delete(string id)
        {
            database db = new database();
            db.AddParameter("@DesigId", id);
            db.AddParameter("@QryType", "D");
            db.ExecuteSP("DesigProc");
        }

        #endregion
    }
}
