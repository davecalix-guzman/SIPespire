using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SI_PESPIRE_Entidades;

namespace SI_PESPIRE_AccesoDatos
{
    public class GenericosAD
    {
        public static string ObtenerCampoId(string nombreEntidad)
        {
            try
            {
                var nombreCampoId = string.Empty;
                var queryConsultaCampoId = new StringBuilder();
                queryConsultaCampoId.Append("SELECT COLUMN_NAME ");
                queryConsultaCampoId.Append("FROM INFORMATION_SCHEMA.COLUMNS ");
                queryConsultaCampoId.AppendFormat($"WHERE TABLE_SCHEMA <> 'dbo' AND TABLE_NAME = '{nombreEntidad}' AND ORDINAL_POSITION = 1");

                using (var cnn = new SqlConnection(ServidorAD.CadenaConexion))
                {
                    cnn.Open();
                    var cmd = new SqlCommand(queryConsultaCampoId.ToString(), cnn);
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        nombreCampoId = Convert.ToString(dr.GetValue(0));
                    }
                    return nombreCampoId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EliminarEntidad(string nombreTablaBd, string nombreCampoId, int valorId)
        {
            try
            {
                var queryEliminarEntidad = new StringBuilder();
                queryEliminarEntidad.Append("DELETE ");
                queryEliminarEntidad.Append($"FROM {nombreTablaBd}");
                queryEliminarEntidad.AppendFormat($" WHERE {nombreCampoId} = {valorId}");

                using (var cnn = new SqlConnection(ServidorAD.CadenaConexion))
                {
                    cnn.Open();
                    var cmd = new SqlCommand(queryEliminarEntidad.ToString(), cnn);
                    var resultado = cmd.ExecuteNonQuery() == 1;
                    return resultado;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string ObtenerNombreTablaBd(string nombreEntidad)
        {
            try
            {
                var nombreTabla = string.Empty;
                var queryConsultaCampoId = new StringBuilder();
                queryConsultaCampoId.Append("SELECT TOP 1 '[' + TABLE_CATALOG +'].['+ TABLE_SCHEMA +'].['+ TABLE_NAME + ']' AS TABLE_NAME ");
                queryConsultaCampoId.Append("FROM INFORMATION_SCHEMA.COLUMNS ");
                queryConsultaCampoId.AppendFormat($"WHERE TABLE_SCHEMA <> 'dbo' AND TABLE_NAME = '{nombreEntidad}'");

                using (var cnn = new SqlConnection(ServidorAD.CadenaConexion))
                {
                    cnn.Open();
                    var cmd = new SqlCommand(queryConsultaCampoId.ToString(), cnn);
                    var dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        nombreTabla = Convert.ToString(dr.GetValue(0));
                    }
                    return nombreTabla;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
