using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Object_fact
    {
        private static int no_fact;
        private static string nombre_pel;
        private static int cantida_taq;
        private static string sala;
        private static float precio_unit;
        private static float total;

        public static string Tipo_usuario;

        public static int No_fact { get => no_fact; set => no_fact = value; }
        public static string Nombre_pel { get => nombre_pel; set => nombre_pel = value; }
        public static int Cantida_taq { get => cantida_taq; set => cantida_taq = value; }
        public static string Sala { get => sala; set => sala = value; }
        public static float Precio_unit { get => precio_unit; set => precio_unit = value; }
        public static float Total { get => total; set => total = value; }
    }
}
