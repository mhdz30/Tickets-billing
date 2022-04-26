using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Data;


namespace Data
{
    public class D_admCartelera
    {
        private ConqBD Connection = new ConqBD();
        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();

        public DataTable ShowCartelera()
        {
            command.Connection = Connection.OpenConnection();
            command.CommandText = "ShowCarteleraxFun";
            command.CommandType = CommandType.StoredProcedure;
            read = command.ExecuteReader();
            table.Load(read);
            Connection.CloseConnection();
            return table;
        }

        public DataTable ShowSala()
        {
            command.Connection = Connection.OpenConnection();
            command.CommandText = "ShowSala";
            command.CommandType = CommandType.Text;
            read = command.ExecuteReader();
            table.Load(read);
            Connection.CloseConnection();
            return table;
        }
        public DataTable ShowFunc()
        {
            command.Connection = Connection.OpenConnection();
            command.CommandText = "ShowFun";
            command.CommandType = CommandType.StoredProcedure;
            read = command.ExecuteReader();
            table.Load(read);
            Connection.CloseConnection();
            return table;
        }
        public void EditCartelera(string fecha, int fun, int sala, string despeli, string fechaIni,
          string fechafin, double preciouni, int noregcar)
        {
            //PROCEDURE

            command.Connection = Connection.OpenConnection();
            command.CommandText = "ERegCartelera";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Fechareg", fecha);
            command.Parameters.AddWithValue("@Id_funcion", fun);
            command.Parameters.AddWithValue("@Id_sala", sala);
            command.Parameters.AddWithValue("@descripcion_pelicula", despeli);
            command.Parameters.AddWithValue("@FechaDispIni", fechaIni);
            command.Parameters.AddWithValue("@FechaDispFin", fechafin);
            command.Parameters.AddWithValue("@precio_unit", preciouni);
            command.Parameters.AddWithValue("@NoReg_Cartelera", noregcar);
      


            command.ExecuteNonQuery();

            command.Parameters.Clear();

        }
    }
}
