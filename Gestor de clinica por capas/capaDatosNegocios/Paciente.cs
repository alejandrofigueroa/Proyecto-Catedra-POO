using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace capaDatosNegocios
{
    public class Paciente
    {
        private int _Id_paciente;
        private string _Nombre;
        private string _Apellido;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Fecha_nacimiento;
        private string _Sexo;
        private int _Fk_idclinica;

        public int Id_paciente
        {
            get
            {
                return _Id_paciente;
            }
            set
            {
                _Id_paciente = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return _Apellido;
            }
            set
            {
                _Apellido = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                _Direccion = value;
            }
        }


        public string Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                _Telefono = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public string Fecha_nacimiento
        {
            get
            {
                return _Fecha_nacimiento;
            }
            set
            {
                _Fecha_nacimiento = value;
            }
        }

        public string Sexo
        {
            get
            {
                return _Sexo;
            }
            set
            {
                _Sexo = value;
            }
        }

        public int FK_IDClinica
        {
            get
            {
                return _Fk_idclinica;
            }
            set
            {
                _Fk_idclinica = value;
            }
        }
    }
}
