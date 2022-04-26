using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class CacheUser
    {
        public static string _Tipo_usuario;

        public static string Tipo_usuario
        {
            get
            {
                return _Tipo_usuario;
            }
            set
            {
                _Tipo_usuario = value;
            }
        }
    }
}
