using SI_PESPIRE_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SI_PESPIRE_AccesoDatos
{
    public class ModulosAD
    {
        public static List<Modulos> ObtenerModulos(bool estado, int menu)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var modulos = dbContext.Modulos.Where(x => x.Estado == estado && x.ModuloId > menu);
                    return modulos.ToList();
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public static List<Modulos> ObtenerModulos()
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var modulos = dbContext.Modulos;
                    return modulos.ToList();
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public static DataTable ObtenerModulosPorRolId(int rolId)
        {
            try
            {
                var strQuery = new StringBuilder();
                strQuery.Append("SELECT  MD.MODULOID, MD.NOMBRE, MD.CLASECSS  FROM [SI_PESPIRE].[dbo].[MODULOS] MD ");
                strQuery.Append("INNER JOIN [SI_PESPIRE].[dbo].[ROLMODULOACCIONES] RMA  ON MD.MODULOID = RMA.FKMODULOID ");
                strQuery.AppendFormat(" WHERE RMA.FKROLID = (" + rolId +") AND MD.ESTADO = 1 AND MD.MODULOID <> 1 GROUP BY MD.MODULOID, MD.NOMBRE, MD.CLASECSS ORDER BY MD.NOMBRE ASC ");
                try
                {
                    using (var cnn = new SqlConnection(ServidorAD.CadenaConexion))
                    {
                        cnn.Open();
                        var cmd = new SqlCommand(strQuery.ToString(), cnn);
                        var da = new SqlDataAdapter(cmd);
                        var ds = new DataSet();
                        da.Fill(ds, "modulos");

                        return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0] : null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}