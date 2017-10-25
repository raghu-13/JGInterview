using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Bsnl.DAL
{
    class database
    {
        SqlCommand cmd = null;

        public void Dispose()
        {
            cmd = null;
        }

        public database()
        {
           
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConString"].ToString());
            cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public void ClearParameters()
        {
            cmd.Parameters.Clear();
        }


        public void AddParameter(string paramname, object paramvalue)
        {
            cmd.Parameters.AddWithValue(paramname, paramvalue);
        }

        public void ExecuteSP(string SPName)
        {
            cmd.CommandText = SPName;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public DataTable GetDataTable(string SPName)
        {
            cmd.CommandText = SPName;
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            return dt;
        }

        public string[] GetDataRow(string SPName)
        {
            cmd.CommandText = SPName;
            cmd.Connection.Open();
            SqlDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string[] row = null;
            if (rd.Read())
            {
                row = new string[rd.FieldCount];
                for (int i = 0; i < row.Length; i++)
                    row[i] = rd[i].ToString();
            }
            rd.Close();
            return row;
        }

        public object GetDataValue(string SPName)
        {
            cmd.CommandText = SPName;
            cmd.Connection.Open();
            object obj = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return obj;
        }


        public string GetMaxId(string SPName)
        {
            SqlParameter param = new SqlParameter();
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);
            cmd.CommandText = SPName;
            cmd.Connection.Open();
            cmd.ExecuteScalar();
            string mid = param.Value.ToString();
            cmd.Connection.Close();
            return mid;
        } 
    }

    }

