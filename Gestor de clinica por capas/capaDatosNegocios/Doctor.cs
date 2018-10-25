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
        private Conexion Conexion = new Conexion();
        private SqlDataReader leer;

        private string especialidad;
        private string descripcion;
        private string fk_empleado;

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

       

        //Iniciando mantenimiento para doctores
        public SqlDataReader insertarDoctor(String especialidad, String descripcion, String fk_empleado)
        {
            SqlCommand comando = new SqlCommand("insertarDoctor", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@especialidad", especialidad);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@fk_idempleado", fk_empleado);
            leer = comando.ExecuteReader();
            return leer;
        }
    }
}
