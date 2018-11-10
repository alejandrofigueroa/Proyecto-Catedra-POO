using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace capaDatosNegocios
{
    public static class BaseDatos
    {

        public static string CadenaConexion { get; set; }


        public static bool TestConexion()
        {
            bool exito = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(CadenaConexion))
                {

                    cn.Open();

                    if (cn.State == ConnectionState.Open) exito = true;
                    else exito = false;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return exito;

        }

        private static int EjecutarSPExecuteNonQuery(string SPName, List<SqlParameter> ListaParametros)
        {
            int numFilasAfectadas = 0;

            try
            {

                using (SqlConnection cn = new SqlConnection(CadenaConexion))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        if (ListaParametros != null && ListaParametros.Count > 0) cmd.Parameters.AddRange(ListaParametros.ToArray());

                        cmd.Connection = cn;
                        cmd.CommandText = SPName;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        numFilasAfectadas = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return numFilasAfectadas;
        }

        private static int Insertar(string SPName, List<SqlParameter> ListaParametros)
        {
            return EjecutarSPExecuteNonQuery(SPName, ListaParametros);
        }

        private static int Modificar(string SPName, List<SqlParameter> ListaParametros)
        {
            return EjecutarSPExecuteNonQuery(SPName, ListaParametros);
        }

        private static int Eliminar(string SPName, List<SqlParameter> ListaParametros)
        {
            return EjecutarSPExecuteNonQuery(SPName, ListaParametros);
        }

        private static DataView DVLista(string SPName, List<SqlParameter> ListaParametros)
        {
            DataSet ds = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(CadenaConexion))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        if (ListaParametros != null && ListaParametros.Count > 0) cmd.Parameters.AddRange(ListaParametros.ToArray());

                        cmd.Connection = cn;
                        cmd.CommandText = SPName;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(ds);
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ds == null || ds.Tables.Count <= 0 ? null : ds.Tables[0].DefaultView;

        }

        private static DataTable DTLista(string SPName, List<SqlParameter> ListaParametros)
        {
            DataSet ds = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(CadenaConexion))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        if (ListaParametros != null && ListaParametros.Count > 0) cmd.Parameters.AddRange(ListaParametros.ToArray());

                        cmd.Connection = cn;
                        cmd.CommandText = SPName;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(ds);
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ds == null || ds.Tables.Count <= 0 ? null : ds.Tables[0];

        }

    }
}
