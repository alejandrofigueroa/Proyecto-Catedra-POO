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
        int id;
        string emisor;
        string receptor;
        string fk_receptor;
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
        public string Fk_receptor1
        {
            get
            {
                return fk_receptor;
            }

            set
            {
                fk_receptor = value;
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
    }
}
