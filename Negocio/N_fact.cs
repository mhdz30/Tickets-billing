using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;


namespace Negocio
{
    public class N_fact 
    {

        D_fact d_Fact = new D_fact();
       
        public DataTable ShowTickets()
        {
            DataTable table = new DataTable();
            table = d_Fact.CalandShowTotalTickets();
            return table;
        }


        public void RegFact(string nombre, string cantidad, string sala, string precio, string total)
        {
            d_Fact.Insert(nombre, Convert.ToInt32(cantidad), sala, Convert.ToDouble(precio), Convert.ToInt32(cantidad));
        }

        public float CALTotal(float cant_tiq, float precio_unit)
        {

            return cant_tiq * precio_unit;
        }
        public bool LogInuser(string user, string pass)
        {
            return d_Fact.LogIn(user, pass);
        }


    }
}
