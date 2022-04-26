using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class ConqBD
    {
        public SqlConnection connection = new SqlConnection("Server=DESKTOP-7J79A2R\\MARIEL; Database=CineMatinee001; integrated security= true; MultipleActiveResultSets=True;");

        public SqlConnection OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }

        public SqlConnection CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            return connection;
        }
        public bool Mac(string mac)
        {
            string StrSql = "select * from MacAddress where mac = '" + mac + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(StrSql, connection);

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
