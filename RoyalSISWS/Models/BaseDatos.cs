using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Text;
using System.IO;
using System.Data;
using RoyalSystems.Data;
using RoyalSISWS.Entidad;
using System.Configuration;

namespace RoyalSISWS.Models
{
    public class BaseDatos
    {

        public static DataTable Consulta(string Unidad, long IdPaciente, string CodigoOA)
        {
            DataSet ds_Result = null;
            DataOperation dop_DataOperation = new DataOperation("SP_SS_HC_ReporteEpisodioClinico");
            Parameter[] prm_Params = new Parameter[3];
            prm_Params[0] = new Parameter("@UnidadReplicacion", Unidad);
            prm_Params[1] = new Parameter("@IdPaciente", IdPaciente); //'CEG'
            prm_Params[2] = new Parameter("@CodigoOA", CodigoOA);
            dop_DataOperation.Parameters.AddRange(prm_Params);
          //  ds_Result = DataManager.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConexionReportes"].ToString(), dop_DataOperation);
            ds_Result = DataManager.ExecuteDataSet(DAT_Conexion.Co_NameConnection, dop_DataOperation);       
            
            if (ds_Result == null || ds_Result.Tables.Count == 0)
            {
                return null;
            }
            return ds_Result.Tables[0];
        }

        public static DataTable SoaValidaFacturacion(int Id, SS_HC_WS_EpisodioAtencion SS_HC_WS_EpisodioAtencion)
        {
            DataSet ds_Result = null;
            try
            {
                if (Id == 1)
                {
                    DataOperation dop_Operacion = new DataOperation("SP_HCE_ITListarValidacion");
                    Parameter[] prm_Params = new Parameter[9];
                    prm_Params[0] = new Parameter("@UnidadReplicacion", SS_HC_WS_EpisodioAtencion.UnidadReplicacion);
                    prm_Params[1] = new Parameter("@IdEpisodioAtencion", SS_HC_WS_EpisodioAtencion.IdEpisodioAtencion);
                    prm_Params[2] = new Parameter("@IdPaciente", SS_HC_WS_EpisodioAtencion.IdPaciente);
                    prm_Params[3] = new Parameter("@EpisodioClinico", SS_HC_WS_EpisodioAtencion.EpisodioClinico);
                    prm_Params[4] = new Parameter("@UsuarioCreacion", SS_HC_WS_EpisodioAtencion.UsuarioCreacion);
                    prm_Params[5] = new Parameter("@IdOrdenAtencion", SS_HC_WS_EpisodioAtencion.IdOrdenAtencion);
                    prm_Params[6] = new Parameter("@Linea", SS_HC_WS_EpisodioAtencion.Linea);
                    prm_Params[7] = new Parameter("@SecuenciaHCE", SS_HC_WS_EpisodioAtencion.SecuenciaHCE);
                    prm_Params[8] = new Parameter("@FechaCreacion", SS_HC_WS_EpisodioAtencion.FechaCreacion);
                    dop_Operacion.Parameters.AddRange(prm_Params);
                    //BaseDatos.WriteLog(System.DateTime.Now + " | " + "Asignacion Correcto : " + " | " + UnidadReplicacion + " | " + IdEpisodioAtencion + " | " + IdPaciente + " | " + EpisodioClinico);
                    ds_Result = DataManager.ExecuteDataSet(DAT_Conexion.Co_NameConnec, dop_Operacion);
                    if (ds_Result == null || ds_Result.Tables.Count == 0)
                    {
                        return null;
                    }
                    return ds_Result.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
              string ddd=  exception.Source;
                //BaseDatos.WriteLog(System.DateTime.Now + " | " + "Error Asignacion: " + " | " + UnidadReplicacion + " | " + IdEpisodioAtencion + " | " + IdPaciente + " | " + EpisodioClinico + " | " + exception.StackTrace);
                return null;
            }
        }

        public static string Insertar(string Unidad)
        {

            return "llego por fin";
        }

        public static string GetXMLFromObject(object o)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                StringWriter sw = new StringWriter();
                XmlTextWriter tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
                return sw.ToString();
            }
            catch (Exception ex)
            {
                //Handle Exception Code   
                return ex.Source;
            }
            //finally
            //{
            //    sw.close();
            //    tw.close();
            //}
        }

        public static XmlElement Serialize(object obj)
        {
            XmlElement serializedXmlElement = null;
            try
            {
                System.IO.MemoryStream memoryStream = new MemoryStream();
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                xmlSerializer.Serialize(memoryStream, obj);
                memoryStream.Position = 0;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(memoryStream);
                serializedXmlElement = xmlDocument.DocumentElement;
            }
            catch (Exception e)
            {
                string sss = e.Source;
                //logging statements. You must log exception for review
            }

            return serializedXmlElement;
        }

        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = Path.GetFullPath("\\Logs\\");
            logFilePath = logFilePath + "RestLog-" + System.DateTime.Today.ToString("yyyy-MM-dd") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        }

    }
}