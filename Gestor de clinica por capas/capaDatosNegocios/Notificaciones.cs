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
    public class Notificaciones
    {
        private Conexion Conexion = new Conexion();
        private SqlDataReader leer;

        int id;
        string emisor;
        string receptor;
        string fk_emisor;
        string mensaje;

        public int Id1
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public string Emisor1
        {
            get
            {
                return emisor;
            }

            set
            {
                emisor = value;
            }
        }
        public string Receptor1
        {
            get
            {
                return receptor;
            }

            set
            {
                receptor = value;
            }
        }
        public string Fk_emisor1
        {
            get
            {
                return fk_emisor;
            }

            set
            {
                fk_emisor = value;
            }
        }

        public string Mensaje1
        {
            get
            {
                return mensaje;
            }

            set
            {
                mensaje = value;
            }
        }
        

        //constructor
        //public CNNotificacion() { }
        //funciones o metodos
        //public SqlDataReader verNotificacion()
        //{
        //    SqlDataReader verNotificacion;
        //    verNotificacion = objDato.verNotificacion(Fk_emisor1);
        //    return verNotificacion;
        //}

        //public SqlDataReader enviarNotificacion()
        //{
        //    SqlDataReader enviarNotificacion;
        //    enviarNotificacion = objDato.enviarNotificacion(Receptor1, Emisor1, Mensaje1, Receptor1);
        //    return enviarNotificacion;
        //}

        //public SqlDataReader borrarNotificacion()
        //{
        //    SqlDataReader borrarNotificacion;
        //    borrarNotificacion = objDato.borrarNotificacion(Id1);
        //    return borrarNotificacion;
        //}

        public List<object> verNotificacion()
        {
            SqlCommand comando = new SqlCommand("clinicas.verNotificacion", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_empleado", Fk_emisor1);
            leer = comando.ExecuteReader();
            List<object> listaDeNotificaciones = new List<object>();
            foreach (string notificacion in leer) {
                listaDeNotificaciones.Add(notificacion);
            }
            return listaDeNotificaciones;
        }

        public SqlDataReader enviarNotificacion(string receptor, string emisor, string mensaje, string idReceptor)
        {
            SqlCommand comando = new SqlCommand("clinicas.enviarNotificacion", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_receptor", idReceptor);
            comando.Parameters.AddWithValue("@receptor", receptor);
            comando.Parameters.AddWithValue("@emisor", emisor);
            comando.Parameters.AddWithValue("@mensaje", mensaje);
            leer = comando.ExecuteReader();
            return leer;
        }

        public SqlDataReader borrarNotificacion(int idNotificacion)
        {
            SqlCommand comando = new SqlCommand("clinicas.verNotificacion", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_notificacion", idNotificacion);
            leer = comando.ExecuteReader();
            return leer;
        }
    }
}
