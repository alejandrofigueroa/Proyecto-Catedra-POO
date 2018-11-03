using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatosNegocios
{
    public class Citas
    {
        private int _IDCitas;
        private string _Fecha;
        private string _Descripcion;
        private double _Precio;
        private int _FK_IDPaciente;
        private int _FK_IDDoctor;

        public int IDCitas
        {
            get{ return _IDCitas; }
            set { _IDCitas = value; }
        }

        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public double Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }

        public int FK_IDPaciente
        {
            get { return _FK_IDPaciente; }
            set { _FK_IDPaciente = value; }
        }

        public int FK_IDDoctor
        {
            get { return _FK_IDDoctor; }
            set { _FK_IDDoctor = value; }
        }
    }
}
