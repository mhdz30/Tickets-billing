using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Data;

namespace Negocio
{
    public class N_rrhh
    {
        rrhh rrhh = new rrhh();
        public DataTable ShowEmp()
        {
            DataTable table = new DataTable();
            table = rrhh.ShowEmp();
            return table;
        }
   
        public float Impuesto(float sb)
        {
            if (sb >= 34334)
            {
                return sb * 15 / 100;
            }
            else
            {
                return 0;
            }

        }
        public void EditEmp(string nombre, string apellidos, string fecha, string sexo,
     string tel, string idemp)
        {
            rrhh.EditEmp(nombre, apellidos, fecha, sexo, tel,
              Convert.ToInt32(idemp));
        }
        public float Afp(float sb)
        {
            return sb * 7 / 100;
        }
        public float Ars(float sb)
        {
            return sb * 3 / 100;
        }
        public float Total_descuento(float isr, float afp, float ars)
        {
            return isr + afp + ars;
        }
        public float Sueldo_neto(float sb, float td)
        {
            return sb - td;
        }


    }
}
