using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data;

namespace Data
{
    public class rrhh
    {
        private ConqBD Connection = new ConqBD();
        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();
        public DataTable ShowEmp()
        {
            command.Connection = Connection.OpenConnection();
            command.CommandText = "Showempleado";
            command.CommandType = CommandType.StoredProcedure;
            read = command.ExecuteReader();
            table.Load(read);
            Connection.CloseConnection();
            return table;
        }
        public void EditEmp(string nombre, string apellidos, string fecha, string sexo, string tel,
        int idemp)
        {
            //PROCEDURE

            command.Connection = Connection.OpenConnection();
            command.CommandText = "Editemp";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre_emp", nombre);
            command.Parameters.AddWithValue("@Aepllidos_emp", apellidos);
            command.Parameters.AddWithValue("@fecha_nac", fecha);
            command.Parameters.AddWithValue("@sexo", sexo);
            command.Parameters.AddWithValue("@telefono", tel);
            command.Parameters.AddWithValue("@Id_emp", idemp);



            command.ExecuteNonQuery();

            command.Parameters.Clear();

        }
    }
}
