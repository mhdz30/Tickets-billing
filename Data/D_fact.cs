using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Comun;

namespace Data
{
    public class D_fact
    {
        private ConqBD Connection = new ConqBD();
        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();
        SqlDataReader dataReader;

        public List<Object_Cartelera> ShowRegCartelera(string busquedaNomPeli, DateTime fechaValida)

        {

            command.Connection = Connection.OpenConnection();
            command.CommandText = "SearchPeliandDate";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@busq", busquedaNomPeli);
            command.Parameters.AddWithValue("@fechavalida", fechaValida.ToShortDateString());

            Connection.OpenConnection();
            dataReader = command.ExecuteReader();
            command.Parameters.Clear();
            List<Object_Cartelera> ListaCartelera = new List<Object_Cartelera>();

            while (dataReader.Read())
            {
                ListaCartelera.Add(new Object_Cartelera
                {
                    NoReg_Cartelera = dataReader.GetInt32(0),
                    Fechareg = dataReader.GetDateTime(1),
                    Id_fun = dataReader.GetInt32(2),
                    Id_sala = dataReader.GetInt32(3),
                    descrip_peli = dataReader.GetString(4),
                    FechaDispIni = dataReader.GetDateTime(5),
                    FechaDispFin = dataReader.GetDateTime(6),
                    precio_unit = dataReader.GetDouble(7),


                });


            }
        dataReader.Close();
            Connection.CloseConnection();
            return ListaCartelera;

        }



        public DataTable ShowTicket()
        {
            command.Connection = Connection.OpenConnection();
            command.CommandText = "ShowTickets";
            command.CommandType = CommandType.StoredProcedure;
            read = command.ExecuteReader();
            table.Load(read);
            Connection.CloseConnection();
            return table;
        }
        public DataTable ShowCartelera()
        {
            DataTable table = new DataTable();
            command.Connection = Connection.OpenConnection();
            command.CommandText = "ShowCartelera";
            command.CommandType = CommandType.StoredProcedure;
            read = command.ExecuteReader();
            table.Load(read);
            read.Close();
            Connection.CloseConnection();
            return table;
        }

        public void Insert(string nombre, int cant_taq, string sala, double precio_unit, double total)
        {
            //PROCEDURE

            command.Connection = Connection.OpenConnection();
            command.CommandText = "RegFact";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nom_pelicula ", nombre);
            command.Parameters.AddWithValue("@Cantidad_taq", cant_taq);
            command.Parameters.AddWithValue("@sala", sala);
            command.Parameters.AddWithValue("@precio_unitario", precio_unit);
            command.Parameters.AddWithValue("@total", total);

            command.ExecuteNonQuery();

            command.Parameters.Clear();

        }

   
        public DataTable CalandShowTotalTickets()
        {
            command.Connection = Connection.OpenConnection();
            command.CommandText = "select No_fact, Nom_pelicula, cantidad_taq, sala, precio_unitario, precio_unitario * Cantidad_taq as total from Factura";
            command.CommandType = CommandType.Text;
            read = command.ExecuteReader();
            table.Load(read);
            Connection.CloseConnection();
            return table;
        }
        public bool LogIn(string user, string pass)
        {

            command.Connection = Connection.OpenConnection();
            command.CommandText = "Select *from UserR where Usuario_idnom=@user and Clave=@pass";

            command.Parameters.AddWithValue("@user", user);
            command.Parameters.AddWithValue("@pass", pass);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read()) {

                    CacheUser.Tipo_usuario = reader.GetString(1);
                }
                    
                return true;


            }
            else
                return false;

        }
    }
}
