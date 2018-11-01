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
    public class Doctor
    {

        private int id_doctor;
        private string especialidad;
        private string descripcion;
        private string fk_empleado;

        public int Id_doctor
        {
            get
            {
                return id_doctor;
            }

            set
            {
                id_doctor = value;
            }
        }
        public string Especialidad
        {
            get
            {
                return especialidad;
            }

            set
            {
                especialidad = value;
            }
        }
        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
        public string Fk_empleado1
        {
            get
            {
                return fk_empleado;
            }

            set
            {
                fk_empleado = value;
            }
        }
    }
}
