using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data;


namespace Negocio
{
    public class N_admCartelera
    {
        D_admCartelera d_AdmCartelera = new D_admCartelera();
        public DataTable ShowCartelera()
        {
            DataTable table = new DataTable();
            table = d_AdmCartelera.ShowCartelera();
            return table;
        }
        public DataTable ShowFunc()
        {
            DataTable table = new DataTable();
            table = d_AdmCartelera.ShowFunc();
            return table;
        }
        public DataTable ShowSala()
        {
            DataTable table = new DataTable();
            table = d_AdmCartelera.ShowSala();
            return table;
        }
        public void EditCartelera(string fechareg, string fun, string sala, string descrpeli,
        string fechaini, string fechafin, string preciounnit, string noregcar)
        {
            d_AdmCartelera.EditCartelera(fechareg, Convert.ToInt32(fun), Convert.ToInt32(sala), descrpeli, fechaini,
              fechafin, Convert.ToDouble(preciounnit), Convert.ToInt32(noregcar));
        }
    }
}
