using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using System.Xml;
using System.Xml.Serialization;
using RoyalSystems.Data;
using System.Reflection;
using System.Transactions;
using System.Data.Common;
using RoyalSISWS.Entidad;
using RoyalSISWS.Models;

namespace RoyalSISWS
{
    /// <summary>
    /// Summary description for SoaService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SoaService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Formulario> ConsultaReporteOA(string Unidad, string IdPaciente, string CodigoOA)
        {
            DataTable dt_TblAdmDet = new DataTable();
            List<Formulario> valores = new List<Formulario>();
            dt_TblAdmDet = BaseDatos.Consulta(Unidad, Convert.ToUInt32(IdPaciente), CodigoOA);
            for (int i = 0; i < dt_TblAdmDet.Rows.Count; i++)
            {
                Formulario form = new Formulario();
                form.Tabla = dt_TblAdmDet.Rows[i]["Tabla"].ToString();
                form.Accion = dt_TblAdmDet.Rows[i]["Accion"].ToString();
                form.Version = dt_TblAdmDet.Rows[i]["Version"].ToString();
                form.TipoFormulario = dt_TblAdmDet.Rows[i]["TipoFormulario"].ToString();
                form.Titulo = dt_TblAdmDet.Rows[i]["Formulario"].ToString();
                form.Ruta = dt_TblAdmDet.Rows[i]["Ruta"].ToString();
                if (!string.IsNullOrEmpty(dt_TblAdmDet.Rows[i]["EpisodioClinico"].ToString())) form.EpisodioClinico = dt_TblAdmDet.Rows[i]["EpisodioClinico"].ToString();
                if (!string.IsNullOrEmpty(dt_TblAdmDet.Rows[i]["EpisodioAtencion"].ToString())) form.EpisodioAtencion = dt_TblAdmDet.Rows[i]["EpisodioAtencion"].ToString();
                valores.Add(form);
            }
            return valores;
        }

        [WebMethod]
        public int InterOperabilidadConsultaExterna(string UnidadReplicacion, int IdEpisodioAtencion, int IdPaciente, int EpisodioClinico)
        {
            string datinicio = "";
            datinicio = " Inicio | " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay;
            try
            {
                DataOperation dop_Operacion = new DataOperation("SP_HCE_ITIDConsultaExterna");
                Parameter[] prm_Params = new Parameter[4];
                prm_Params[0] = new Parameter("@UnidadReplicacion", UnidadReplicacion);
                prm_Params[1] = new Parameter("@IdEpisodioAtencion", IdEpisodioAtencion);
                prm_Params[2] = new Parameter("@IdPaciente", IdPaciente);
                prm_Params[3] = new Parameter("@EpisodioClinico", EpisodioClinico);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_NameConnec, dop_Operacion);
                BaseDatos.WriteLog(datinicio + " |Fin" + DateTime.Now + " | " + "Asignacion Correcto : SP_HCE_ITIDConsultaExterna " + " | " + UnidadReplicacion + " | " + IdEpisodioAtencion + " | " + IdPaciente + " | " + EpisodioClinico);
                return 1;
            }
            catch (Exception exception)
            {
                string dd = exception.Source;
                BaseDatos.WriteLog(datinicio + " |Fin" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay +
                    " | " + "Error Asignacion: EXEC SP_HCE_ITIDConsultaExterna '" + UnidadReplicacion + "'," + IdEpisodioAtencion + "," + IdPaciente + "," + EpisodioClinico +
                    " | " + exception.StackTrace + " | " + dd);
                return 0;
            }
        }

        [WebMethod]
        public int InterOperabilidadSalida(string UnidadReplicacion, int IdEpisodioAtencion, int IdPaciente, int EpisodioClinico)
        {
            string datinicio = "";
            datinicio = " Inicio | " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay;
            try
            {
                DataOperation dop_Operacion = new DataOperation("SP_HCE_InteroperabilidadSalidaV0002");
                Parameter[] prm_Params = new Parameter[4];
                prm_Params[0] = new Parameter("@UnidadReplicacion", UnidadReplicacion);
                prm_Params[1] = new Parameter("@IdEpisodioAtencion", IdEpisodioAtencion);
                prm_Params[2] = new Parameter("@IdPaciente", IdPaciente);
                prm_Params[3] = new Parameter("@EpisodioClinico", EpisodioClinico);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_NameConnec, dop_Operacion);
                BaseDatos.WriteLog(datinicio + " |Fin" + DateTime.Now + " | " + "Firma Correcta : SP_HCE_InteroperabilidadSalidaV0002" + " | " + UnidadReplicacion + " | " + IdEpisodioAtencion + " | " + IdPaciente + " | " + EpisodioClinico);
                return 1;
            }
            catch (Exception exception)
            {
                string dd = exception.StackTrace;
                BaseDatos.WriteLog(datinicio + " |Fin" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay +
                    " | " + "Error Asignacion: EXEC SP_HCE_InteroperabilidadSalidaV0002 '" + UnidadReplicacion + "'," + IdEpisodioAtencion + "," + IdPaciente + "," + EpisodioClinico +
                    " | " + exception.StackTrace + " | " + dd);
                return 0;
            }
        }

        [WebMethod]
        public DataTable SoaValidaFacturacion(int Id, SS_HC_WS_EpisodioAtencion SS_HC_WS_EpisodioAtencion)
        {
            DataSet ds_Result = null;
            string datinicio = "";
            datinicio = " Inicio " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay;
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
                    ds_Result = DataManager.ExecuteDataSet(DAT_Conexion.Co_NameConnec, dop_Operacion);

                    //BaseDatos.WriteLog(datinicio + " |Fin " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay +
                    //    " Correcto : Exec SP_HCE_ITListarValidacion UnidadReplicacion='" + SS_HC_WS_EpisodioAtencion.UnidadReplicacion +
                    //    "' ,IdEpisodioAtencion= " + SS_HC_WS_EpisodioAtencion.IdEpisodioAtencion + " ,IdPaciente= " + SS_HC_WS_EpisodioAtencion.IdPaciente +
                    //    " ,EpisodioClinico=" + SS_HC_WS_EpisodioAtencion.EpisodioClinico + " ,UsuarioCreacion='" + SS_HC_WS_EpisodioAtencion.UsuarioCreacion +
                    //    " ,IdOrdenAtencion=" + SS_HC_WS_EpisodioAtencion.IdOrdenAtencion + " ,Linea=" + SS_HC_WS_EpisodioAtencion.Linea +
                    //    "' ,SecuenciaHCE='" + SS_HC_WS_EpisodioAtencion.SecuenciaHCE + "' ,FechaCreacion= NULL"
                    //);
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
                string dd = exception.Source;
                BaseDatos.WriteLog(datinicio + " |Fin " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.TimeOfDay +
                        " | " +  "Correcto : Exec SP_HCE_ITListarValidacion UnidadReplicacion='" + SS_HC_WS_EpisodioAtencion.UnidadReplicacion +
                        "' ,IdEpisodioAtencion= " + SS_HC_WS_EpisodioAtencion.IdEpisodioAtencion + " ,IdPaciente= " + SS_HC_WS_EpisodioAtencion.IdPaciente +
                        " ,EpisodioClinico=" + SS_HC_WS_EpisodioAtencion.EpisodioClinico + " ,UsuarioCreacion='" + SS_HC_WS_EpisodioAtencion.UsuarioCreacion +
                        " ,IdOrdenAtencion=" + SS_HC_WS_EpisodioAtencion.IdOrdenAtencion + " ,Linea=" + SS_HC_WS_EpisodioAtencion.Linea +
                        "' ,SecuenciaHCE='" + SS_HC_WS_EpisodioAtencion.SecuenciaHCE + "' ,FechaCreacion= NULL" +
                    " | " + exception.StackTrace + " | " + dd);
                return null;
            }
        }

        [WebMethod]
        public DataTable SoaValidaFacturacionPrueba(int Id, string UnidadReplicacion, int IdEpisodioAtencion, int IdPaciente, int EpisodioClinico, int IdOrdenAtencion, int Linea, string SecuenciaHCE)
        {
            DataSet ds_Result = null;
            try
            {
                if (Id == 1)
                {
                    DataOperation dop_Operacion = new DataOperation("SP_HCE_ITListarValidacion");
                    Parameter[] prm_Params = new Parameter[9];
                    prm_Params[0] = new Parameter("@UnidadReplicacion", UnidadReplicacion);
                    prm_Params[1] = new Parameter("@IdEpisodioAtencion", IdEpisodioAtencion);
                    prm_Params[2] = new Parameter("@IdPaciente", IdPaciente);
                    prm_Params[3] = new Parameter("@EpisodioClinico", EpisodioClinico);
                    prm_Params[4] = new Parameter("@UsuarioCreacion", "");
                    prm_Params[5] = new Parameter("@IdOrdenAtencion", IdOrdenAtencion);
                    prm_Params[6] = new Parameter("@Linea", Linea);
                    prm_Params[7] = new Parameter("@SecuenciaHCE", SecuenciaHCE);
                    prm_Params[8] = new Parameter("@FechaCreacion", "");
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
                string dd = exception.Source;
                //BaseDatos.WriteLog(System.DateTime.Now + " | " + "Error Asignacion: " + " | " + UnidadReplicacion + " | " + IdEpisodioAtencion + " | " + IdPaciente + " | " + EpisodioClinico + " | " + exception.StackTrace);
                return null;
            }
        }

        [WebMethod]
        public string SoaHistoria(int Id, SS_HC_WS_EpisodioAtencion SS_HC_WS_EpisodioAtencion)
        {
            if (Id == 1)
            {
                DataTable Cabecera = new DataTable();
                SS_HC_WS_EpisodioAtencion.UsuarioCreacion = "VER_ATENCIONES";
                Cabecera = BaseDatos.SoaValidaFacturacion(Id, SS_HC_WS_EpisodioAtencion);

                string codigooa = "";
                string Modalidad = "";
                string Medico = "";
                string IdConsultaExterna = "";
                //string discountDelivery = "";
                //decimal monto = 0;

                foreach (DataRow Maestro in Cabecera.AsEnumerable())
                {
                    codigooa = Maestro["codigooa"].ToString();
                    Modalidad = Maestro["Modalidad"].ToString();
                    Medico = Maestro["Medico"].ToString();
                    IdConsultaExterna = Maestro["IdConsultaExterna"].ToString();
                    //discountDelivery = Maestro["discountDeliveryG"].ToString();
                }

                DataTable ItemsAmna = new DataTable();
                SS_HC_WS_EpisodioAtencion.UsuarioCreacion = "VISORANAMNESIS";
                ItemsAmna = BaseDatos.SoaValidaFacturacion(Id, SS_HC_WS_EpisodioAtencion);

                DataTable ItemsApoyo = new DataTable();
                SS_HC_WS_EpisodioAtencion.UsuarioCreacion = "VISORAPOYO";
                ItemsAmna = BaseDatos.SoaValidaFacturacion(Id, SS_HC_WS_EpisodioAtencion);

                DataTable ItemsDesca = new DataTable();
                SS_HC_WS_EpisodioAtencion.UsuarioCreacion = "VISORMEDICO";
                ItemsAmna = BaseDatos.SoaValidaFacturacion(Id, SS_HC_WS_EpisodioAtencion);

                DataTable ItemsGineco = new DataTable();
                SS_HC_WS_EpisodioAtencion.UsuarioCreacion = "VISORGINECO";
                ItemsAmna = BaseDatos.SoaValidaFacturacion(Id, SS_HC_WS_EpisodioAtencion);

                var grid = new
                {
                    codigooa = codigooa,
                    modalidad = Modalidad,
                    medico = Medico,
                    idconsultaexterna = IdConsultaExterna,
                    ItemsAmna,
                    ItemsApoyo,
                    ItemsDesca,
                    ItemsGineco
                };
                return "";
                //return JsonConvert.SerializeObject(grid, Newtonsoft.Json.Formatting.Indented);
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public string SoaPassword(int Id, string txtPassword)
        {
            //string contrasenaEncriptada = LibEncrypt.Class1.Encrypt(txtPassword);
            return txtPassword;
        }

        //Estrutura do XML de funcionário
        public class Funcionario
        {
            [XmlElement("idt_func")]
            public string idt_func { get; set; }

            [XmlElement("cpf")]
            public string cpf_func { get; set; }

            [XmlElement("nome")]
            public string nom_func { get; set; }

            [XmlElement("rg")]
            public string ci_func { get; set; }

            [XmlElement("email")]
            public string email_func { get; set; }

            [XmlElement("tel_residencial")]
            public string tel_res_func { get; set; }

            [XmlElement("tel_celular")]
            public string tel_cel_func { get; set; }

            [XmlElement("data_nascimento")]
            public string dat_nasc_func { get; set; }

            [XmlElement("sexo")]
            public string sexo_func { get; set; }
        }

        //Classe que recebe a lista de funcionário e retorna o XML
        [XmlRoot("xml")]
        public class xml
        {
            public xml() { }
            public xml(List<Funcionario> funcionarios)
            {
                this.funcionarios = funcionarios;
            }
            public List<Funcionario> funcionarios { get; set; }
        }

        //Criando dados fictícios de funcionários
        public DataTable DadosFuncionarios()
        {
            DataTable dteDadosFunc = new DataTable();
            dteDadosFunc.Columns.Add("idt_func");
            dteDadosFunc.Columns.Add("cpf_func");
            dteDadosFunc.Columns.Add("nom_func");
            dteDadosFunc.Columns.Add("ci_func");
            dteDadosFunc.Columns.Add("email_func");
            dteDadosFunc.Columns.Add("tel_res_func");
            dteDadosFunc.Columns.Add("tel_cel_func");
            dteDadosFunc.Columns.Add("dat_nasc_func");
            dteDadosFunc.Columns.Add("sexo_func");

            dteDadosFunc.Rows.Add(1, "123.456.789-10", "José Silva", "11111111", "jose@teste.com", "", "9999-8888", "01/01/2000", "M");
            dteDadosFunc.Rows.Add(2, "321.654.987-01", "Maria dos Santos", "222222222", "maria@teste.com", "2412-3546", "8888-7777", "01/01/1998", "F");
            dteDadosFunc.Rows.Add(3, "147.258.369-78", "Epaminondas Soares", "33333333", "epaminondas@teste.com", "", "9878-9878", "10/05/1990", "M");
            dteDadosFunc.Rows.Add(4, "741.852.963-63", "Astrogildo Pereira", "44444444", "astrogildo@teste.com", "3254-6588", "", "01/01/2002", "M");
            dteDadosFunc.Rows.Add(5, "987.654.321-00", "Marvio Costa", "555555", "marvio@teste.com", "", "9154-7899", "13/08/1996", "M");
            dteDadosFunc.Rows.Add(6, "789.456.123-55", "Silviano Neto", "66666666", "silviano@teste.com", "4156-3621", "", "01/12/1987", "M");
            dteDadosFunc.Rows.Add(7, "326.159.487-65", "Justina Pimentel", "777777", "justina@teste.com", "", "8163-5544", "20/05/1985", "F");

            return dteDadosFunc;
        }

        //Criando dados fictícios de funcionários
        public DataTable OrdenAceptada()
        {
            DataTable dteOrden = new DataTable();
            dteOrden.Columns.Add("CodigoAtencion");
            dteOrden.Columns.Add("CodigoOrden");
            dteOrden.Columns.Add("CodigoIngreso");
            dteOrden.Columns.Add("FechaRecepcionOrden");
            dteOrden.Columns.Add("HoraRecepcionOrden");
            dteOrden.Columns.Add("CodigoExcepcion");
            dteOrden.Columns.Add("Comentario");

            dteOrden.Rows.Add(1, "123.456.789-10", "José Silva", "11111111", "jose@teste.com", "", "9999-8888", "01/01/2000", "M");

            return dteOrden;
        }

        public DataTable DadosCodigoBarras()
        {
            DataTable dteBarras = new DataTable();
            dteBarras.Columns.Add("CodigoBarra");
            dteBarras.Columns.Add("Identificador");
            dteBarras.Columns.Add("Nombre");
            dteBarras.Columns.Add("CodigoArea");

            dteBarras.Rows.Add("240000302", "[MORADO]", "", "U3E");
            dteBarras.Rows.Add("240000302", "[NEGRO]", "", "U3E");
            dteBarras.Rows.Add("240000302.1", "[ROJO]", "Suero", "U3E");
            dteBarras.Rows.Add("240000302.41", "[ORINAS]", "Glucosa de Orina", "U3E");
            dteBarras.Rows.Add("240000302.58", "[ORINAS]", "PROTEINAS EN ORINAS", "U3E");
            dteBarras.Rows.Add("240000302.NTX", "[ORINAS]", "NTX", "U3E");
            dteBarras.Rows.Add("240000302.ORI", "[ORINAS]", "ORINA, EXAMEN COMPLETO", "U3E");

            return dteBarras;
        }
    }

    public class Formulario
    {
        public string Tabla, Accion, Version, TipoFormulario, Ruta, Titulo, EpisodioClinico, EpisodioAtencion;
        //public int EpisodioClinico, EpisodioAtencion;

        public Formulario() { }

        public Formulario(string titulo, string tabla, string accion, string version, string tipoformulario, string ruta, string episodioclinico, string episodioatencion)
        {
            Titulo = titulo;
            Tabla = tabla;
            Accion = accion;
            Version = version;
            TipoFormulario = tipoformulario;
            Ruta = ruta;
            EpisodioClinico = episodioclinico;
            EpisodioAtencion = episodioatencion;
        }
    }
}
