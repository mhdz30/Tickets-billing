using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Object_Cartelera
    {
        int _NoReg_Cartelera;
        DateTime _fechareg;
        int _id_fun;
        int _id_sala;
        string _descrip_peli;
        DateTime _FechaDispIni;
        DateTime _FechaDispFin;
        double _precio_unit;

        public int NoReg_Cartelera
        {
            get
            {
                return _NoReg_Cartelera;
            }
            set
            {
                _NoReg_Cartelera = value;
            }
        }
        public DateTime Fechareg
        {
            get
            {
                return _fechareg;
            }
            set
            {
                _fechareg = value;
            }
        }


        public int Id_fun
        {
            get
            {
                return _id_fun;
            }
            set
            {
                _id_fun = value;
            }
        }
        public int Id_sala
        {
            get
            {
                return _id_sala;
            }
            set
            {
                _id_sala = value;
            }
        }
        public string descrip_peli
        {
            get
            {
                return _descrip_peli;
            }
            set
            {
                _descrip_peli = value;
            }
        }
        public DateTime FechaDispIni
        {
            get
            {
                return _FechaDispIni;
            }
            set
            {
                _FechaDispIni = value;
            }
        }
        public DateTime FechaDispFin
        {
            get
            {
                return _FechaDispFin;
            }
            set
            {
                _FechaDispFin = value;
            }
        }
        public double precio_unit
        {
            get
            {
                return _precio_unit;
            }
            set
            {
                _precio_unit = value;
            }
        }
    }
}
