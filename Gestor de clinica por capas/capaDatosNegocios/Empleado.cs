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
    public class Empleado
    {
        private Conexion Conexion = new Conexion();
        private SqlDataReader leer;
        //variables
        private String _Nombre;
        private String _Apellido;
        private String _Direccion;
        private String _Telefono;
        private String _Dui;
        private String _Genero;
        private String _usuario;
        private String _pass;
        private String _Fk_IDClinica;
        private String _esquema;

        //Metdos GET y SET --> para manejo de variables
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Apellido
        {
            get { return Apellido; }
            set { Apellido = value; }
        }


        public string Direccion
        {
            get { return Direccion; }
            set { Direccion = value; }
        }
        public string Telefono1
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
        public string Dui
        {
            get
            {
                return _Dui;
            }

            set
            {
                _Dui = value;
            }
        }
        public string Genero1
        {
            get
            {
                return _Genero;
            }

            set
            {
                _Genero = value;
            }
        }
        public string Usuario1
        {
            get
            {
                return _usuario;
            }

            set
            {
                if (value == "USUARIO")
                {
                    _usuario = "No ha ingresado usuario";
                }
                else
                {
                    _usuario = value;
                }
            }
        }

        public string Pass
        {
            get
            {
                return _pass;
            }
            set
            {
                if (value == "CONTRASEÑA")
                {
                    _pass = "No ha ingresado una contraseña";
                }
                else
                {
                    _pass = value;
                }
            }
        }
        public string Fk_IDClinica1
        {
            get
            {
                return _Fk_IDClinica;
            }

            set
            {
                _Fk_IDClinica = value;
            }
        }
        public string Esquema1
        {
            get
            {
                return _esquema;
            }

            set
            {
                _esquema = value;
            }
        }

        
        //Mando a llamar el procedimiento almacenado para inicar sesion en la base de datos
        public SqlDataReader iniciarSesion(String user, String pass)
        {
            SqlCommand comando = new SqlCommand("clinicas.SPIniciarSesion", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", user);
            comando.Parameters.AddWithValue("@pass", pass);
            leer = comando.ExecuteReader();
            return leer;
        }
        public SqlDataReader IniciarSesion()
        {
            SqlDataReader Logear;
            Logear = iniciarSesion(Usuario1, Pass);
            return Logear;
        }
    }
}
