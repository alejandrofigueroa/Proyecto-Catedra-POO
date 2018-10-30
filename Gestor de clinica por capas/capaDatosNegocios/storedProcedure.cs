using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace capaDatosNegocios
{
    public class storedProcedure
    {
        private Conexion Conexion = new Conexion();
        private SqlDataReader leer;
        string sql;

        public bool pb(string[] obj, string nsp) //sirve para insertar, actualizar y borrar, devuelve true o false
        {
            try
            {
                SqlCommand comando = new SqlCommand("clinicas." + nsp, Conexion.cnn);//creamos el query, pero esta vez solo le enviaremos el procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;//especificamos que el comando con el query es de tipo procedimiento almacenado
                
                foreach (string p in obj)
                {//en obj vienen los parametros para enviar a nuestro procedimiento almacenado, cada parametro lo almacenaremos en p
                    string[] words = new string[2];//creamos un array para separar el nombre del parametro con el parametro en sí
                    words = p.Split('=');//le decimos que nos separe nuestro parametro, el nombre del parametro se almacenará en word[0] y el parametro en word[1]
                    words[0] = words[0].Trim(' ');//limpiamos el nombre del parametro por si queda un espacio en blanco
                    words[1] = words[1].Trim(' ');//limpiamos el parametro por si queda un espacio en blanco
                    comando.Parameters.AddWithValue(words[0], words[1]);//enviamos el parametro para nuestro procedimiento almacenado, aqui agregaremos varios parametros por el foreach
                   
                }
                Conexion.AbrirConexion();
                int co = comando.ExecuteNonQuery();
                Conexion.cerrarConexion();
                return true;//si executo el procedimiento con exito devolverá true
                
            }
            catch(Exception e)
            {
                return false;//si no se ejecuto el procedimiento devolverá false
            }
        }
        public bool pb(object[,] obj, string nsp) //sirve para insertar, actualizar y borrar, devuelve true o false
        {
            try
            {
                SqlCommand comando = new SqlCommand("clinicas." + nsp, Conexion.cnn);//creamos el query, pero esta vez solo le enviaremos el procedimiento almacenado

                comando.CommandType = CommandType.StoredProcedure;//especificamos que el comando con el query es de tipo procedimiento almacenado

                for (int i = 0; i < (obj.Length) / 2; i++)
                {//en obj vienen los parametros para enviar a nuestro procedimiento almacenado, cada parametro lo almacenaremos en p
                    object[] words = new object[2];//creamos un array para separar el nombre del parametro con el parametro en sí
                    for (int j = 0; j < 2; j++)
                    {
                        words[j] = obj[i, j];
                    }
                    comando.Parameters.AddWithValue(words[0].ToString(), words[1]);//enviamos el parametro para nuestro procedimiento almacenado, aqui agregaremos varios parametros por el foreach
                }
            Conexion.AbrirConexion();
            comando.ExecuteReader();
            Conexion.cerrarConexion();
                return true;//si executo el procedimiento con exito devolverá true
            }
            catch (Exception exe)
            {
                return false;//si executo el procedimiento con exito devolverá true
            }
        }
        public DataTable dt(string tabla) //sirve obtener todos los datos una tabla de la base de datos para mostrarlos en un datagridview
            //obtenemos como parametro la tabla que queremos consultar
        {
            DataTable table = new DataTable();//creamos una nueva tabla vacia

            try
            {
                var select = "select * from " + tabla + ";";//creamos un query diciendole que seleccionaremos todos los datos de la tabla parametro
                var dataAdapter = new SqlDataAdapter(select, Conexion.AbrirConexion());// creamos un data adapter
                var commandBuilder = new SqlCommandBuilder(dataAdapter);//construimos la consulta
                var ds = new DataSet();//creamos un nuevo dataset
                dataAdapter.Fill(ds);//seteamos los datos
                return ds.Tables[0];//devolvemos la tabla que obtuvimos de la base de datos
                
            }
            catch (Exception e)
            {

                return null;//si hubo algun error retornará una tabla nula
            }
        }

        public DataTable dt(string[] obj, string nsp)//sirve para obtener una tabla de la base de datos con valores especificos
        {
            DataTable table = new DataTable();//creamos una tabla vacia

            try
            {
                foreach (string parametro in obj)//obtenemos los parametros que nos han enviado
                {
                    sql += parametro;//los almacenamos en un string 
                }

                using (SqlCommand command = new SqlCommand("exec clinicas." + nsp + " " + sql + ";", Conexion.AbrirConexion())) //creamos la consulta con los parametros (sql) y el nombre del procedimiento almacenado
                {
                    SqlDataReader reader = command.ExecuteReader();//ejecutamos el reader
                    foreach (var data in reader) {//por cada valor que contenga el reader lo almacenaremos en data
                        table.Rows.Add(data.ToString());//agregamos data en las filas de nuestra tabla
                    }
                    leer.Close();//cerramos el reader
                    return  table;//retornamos la tabla
                }
            }
            catch (Exception e)
            {
                
                return null;//retornamos una tabla nula si falla algo
            }
        }

        public List<object[]> lt(string[] obj, string nsp) //retorna un objeto tipo lista
        {
            try
            {
                SqlCommand comando = new SqlCommand("clinicas." + nsp, Conexion.AbrirConexion());//creamos el query, pero esta vez solo le enviaremos el procedimiento almacenado
                comando.CommandType = CommandType.StoredProcedure;//especificamos que el comando con el query es de tipo procedimiento almacenado
                foreach (string p in obj) {//en obj vienen los parametros para enviar a nuestro procedimiento almacenado, cada parametro lo almacenaremos en p
                    string[] words = new string[2];//creamos un array para separar el nombre del parametro con el parametro en sí
                    words = p.Split('=');//le decimos que nos separe nuestro parametro, el nombre del parametro se almacenará en word[0] y el parametro en word[1]
                    words[0] = words[0].Trim(' ');//limpiamos el nombre del parametro por si queda un espacio en blanco
                    words[1] = words[1].Trim(' ');//limpiamos el parametro por si queda un espacio en blanco
                    comando.Parameters.AddWithValue(words[0], words[1]);//enviamos el parametro para nuestro procedimiento almacenado, aqui agregaremos varios parametros por el foreach
                }
                leer = comando.ExecuteReader();//ejecutamos el comando para obtener los datos del procedimiento almacenado
                
                List<object[]> lista = new List<object[]>();//creamos una lista de arrays para almacenar las filas de la tabla de la base de datos
                while (leer.Read())//leerá hasta que ya no encuentre que leer
                {
                    object[] filas = new string[leer.FieldCount];//columnas almacenará los campos , fieldcount cuanta cuantas columnas hay en la tabla, pero nos servirá para definir cuantos campos ingresar en nuestra fila
                    for (int j = 0; j < leer.FieldCount; j++)//repetiremos hasta que nos quedemos sin columnas
                    {
                        filas[j] = String.Format("{0}", leer[j]);//ingresamos el campo a la fila
                    }
                    lista.Add(filas);//agregamos la fila a la lista
                }
                leer.Close();//cerramos el reader
                return lista;//retornamos la lista de arrays
            }
            catch (Exception e)
            {

                return null;//devolvemos null por si falla algo
            }
        }


        

    }
}


//Forma de usar el list:

/*
  string[] notiParametros = new string[1];//creamos un string para los parametros
  notiParametros[0] = "@id_usuario = " + MenuVertical.usuarioSesion + "";//guardamos los parametros que queremos, no le ponemos las comillas simples al parametro, dará error

  List<string[]>datos = sp.lt(notiParametros, "verNotificacion");//mandamos a llamar la clase sp con la funcion lt

  foreach (string[] notificacion in datos)//cargamos los datos en nuestra lista
  {
      listNotificaciones.Items.Add("["+notificacion[1]+"] -"+notificacion[2]);
  }
*/


//Forma de usar el dataTable para seleccionar todo:

/*
   private void actualizarDatos() {
            dvgDoctores.DataSource = sp.dt("Doctor");//mandamos a llamar la clase sp con la funcion dt y de parametro solo le ponemos la tabla y lo mostramos en el datagridvie
        }
*/

//Forma de usar el dataTable para seleccionar valores especificos:

/*
  
*/

//Forma de usar el procedure bool (pb) para Insertar, borrar, actualizar Datos:

/*
  string[] docParametros = new string[3];//creamos el array para mandar parametros
  //creamos los parametros que enviaremos, en este caso si le pondremos comillas simples mas una coma, exceptuando el ultimo parametro a diferencia de la lista que no se les ponen
            docParametros[0] = "@especialidad = '" + textBox1.Text + "',";
            docParametros[1] = "@descripcion_personal = '" + textBox2.Text + "',";
            docParametros[2] = "@FK_IDUsuario = '" + cboUsuario.SelectedItem.ToString() + "'";

            if (sp.pb(docParametros, "insertarDoctor"))//al mandar a llamar la funcion debolverá un valor booleano con eso podemos controlarlo
            {
                MenuVertical.errores = "Datos creados correctamente";//si tira true, pondremos que todo esta bien
                actualizarDatos();//actualizamos el datagrid
            }
            else//si tira false, quiere decir que intentamos actualizar los datos por que los datos ya existen
            {
                if (sp.pb(docParametros, "actualizarDoctor"))//mandamos a llamar de nuebo el pb, pero en este caso le diremos que queremos actualizar
                {
                    MenuVertical.errores = "Datos alterados correctamente";//si tira true diremos que todo esta bien
                    actualizarDatos();
                }
                else
                {
                    MenuVertical.errores = "No se alterar alterar los datos, verifique bien los campos";//quiere decir que no estamos enviando bien los parametros
                }
            }
*/
