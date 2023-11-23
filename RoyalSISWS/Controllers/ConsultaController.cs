using Newtonsoft.Json;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.DirectoryServices;  //Hay que añadirlo en References
using System.DirectoryServices.AccountManagement;
using System.Text;

using RoyalSISWS.Models;
using RoyalSISWS.Models.Entidades;
using RoyalSISWS.Models.SpringSalud_produccion;
using RoyalSISWS.Entidad;
using RoyalSISWS.BasicAuthentication;
using RoyalSISWS.Models.WEB_ERPSALUD;
using System.Text.RegularExpressions;

namespace RoyalSISWS.Controllers
{
    public class ConsultaController : Controller
    {
        //
        // GET: /Consulta/

        Metodos m = new Metodos();

        public ActionResult Index()
        {
            return View();
        }

        #region ActiveDirectory

        public JsonResult ListarPassword(String Usuario, String Password)
        {
            List<ResponseData> Resultado = new List<ResponseData>();
            ResponseData ObjREs = new ResponseData();
            try
            {
                List<SP_ParametrosMastListar_Result> listParamWService = new List<SP_ParametrosMastListar_Result>();
                SP_ParametrosMastListar_Result objParam = new SP_ParametrosMastListar_Result();
                objParam.Accion = "LISTAR";
                objParam.CompaniaCodigo = "999999";
                objParam.AplicacionCodigo = "WA";//obs  
                objParam.ParametroClave = "RUTA_WSALD";
                listParamWService = m.listarParametro(objParam, 0, 0);
                if (listParamWService.Count > 0)
                {
                    String SERVER = (listParamWService[0].Texto.Trim() + "").Trim();
                    String URL_SERVER = (listParamWService[0].DescripcionParametro.Trim() + "").Trim();
                    if (SERVER == "S")
                    {
                        string contrasenaEncriptada = Password; //LibEncrypt.Class1.Encrypt(Password);
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri(URL_SERVER);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage response = client.GetAsync("ws_dev_getEmpleado1/" + Usuario.Trim() + "/" + contrasenaEncriptada).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            Resultado = (List<ResponseData>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<ResponseData>));
                            return Json(Resultado, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            ObjREs.TipoPago = "Error";
                            Resultado.Add(ObjREs);
                            return Json(Resultado, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        ObjREs.TipoPago ="";
                        Resultado.Add(ObjREs);
                        return Json(Resultado, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    ObjREs.TipoPago ="";
                    Resultado.Add(ObjREs);
                    return Json(Resultado, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ObjREs.TipoPago = "Error";
                ObjREs.Nombre = ex.Message;
                Resultado.Add(ObjREs);
                return Json(Resultado, JsonRequestBehavior.AllowGet);
            }
        }
          
        public DirectoryEntry GetUser(string path, string admUser, string admPass, string UserName, ref string cErr)
        {
            cErr = "";
            DirectoryEntry de = null;

            try
            {
                de = GetDirectoryObject(path, admUser, admPass, ref cErr);
                DirectorySearcher deSearch = new DirectorySearcher();
                deSearch.SearchRoot = de;

                deSearch.Filter = "(&(objectClass=user)(SAMAccountName=" + UserName + "))";
                deSearch.SearchScope = SearchScope.Subtree;
                SearchResult results = deSearch.FindOne();

                if (results != null)
                    de = new DirectoryEntry(results.Path, admUser, admPass, AuthenticationTypes.Secure);
                else
                    de = null;
            }
            catch (Exception ex)
            {
                cErr = ex.Message;
                de = null;
            }
            return de;
        }

        public DirectoryEntry GetDirectoryObject(string path, string user, string pass, ref string cErr)
        {
            cErr = "";
            DirectoryEntry de;

            try
            {
                de = new DirectoryEntry(path, user, pass, AuthenticationTypes.Secure);
            }
            catch (Exception ex)
            {
                cErr = ex.Message;
                de = null;
            }
            return de;
        }


        #endregion


        #region CitaHistoria
        
        public ActionResult  ListarVisorHistoria(Nullable<int> Accion, string tipoDocumento, string Documento, string cod_sucursal)
        {
            try
            {
                List<CW_VisorHistoria> lstSalida = new List<CW_VisorHistoria>();
                if (Accion == 1)
                {
                    CW_DisponibilidadMedica VisorHistoria = new CW_DisponibilidadMedica();
                    VisorHistoria.UnidadReplicacion = tipoDocumento;
                    VisorHistoria.CMP = Documento;
                    VisorHistoria.IdHorario = 1;
                    VisorHistoria.IdEspecialidad_Nombre = cod_sucursal;

                    List<VW_SS_HCE_VisorHistoria> lst = new List<VW_SS_HCE_VisorHistoria>();
                    lst = m.HCE_VisorHistoria(VisorHistoria);

                   
                   //  string Jsons = Newtonsoft.Json.JsonConvert.SerializeObject(lstSalida);
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(lst);

                    //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    //serializer.MaxJsonLength = serializer.MaxJsonLength;
                    //int MaxValue = 99999990; // Establece un valor muy alto o el necesario según tus necesidades
                    //jsonString = serializer.Serialize(lst);
                    jsonString  = jsonString.Replace("\n","");  

                    jsonString = Regex.Replace(jsonString, @"[^\u0000-\u007F]+", string.Empty);

                    //var prueba = JsonConvert.DeserializeObject<List<VW_SS_HCE_VisorHistoria>>(jsonString);
                    //BaseDatos.WriteLog(System.DateTime.Now + " | " + lstSalida);
                    return Content(jsonString, "application/json");
                }
                else
                {
                    return Json("Error: Valores de Parametro ", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception exception)
            {
                string dd = exception.Source;
                BaseDatos.WriteLog(System.DateTime.Now + " | " + "Error Asignacion: SELECT * FROM CW_VisorHistoria WHERE UnidadReplicacion= '" + tipoDocumento + "' AND Documento='" + Documento + "' AND Sucursal='" + cod_sucursal + "' | " + exception.StackTrace + " | " + dd);
                return Json("Error : " + " | " + exception.StackTrace, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ListarVisorHistoriaFecha(Nullable<int> Accion, string tipoDocumento, string Documento, DateTime FechaInicio, DateTime FechaFin, string cod_sucursal)
        {
            try
            {
                List<CW_VisorHistoria> lstSalida = new List<CW_VisorHistoria>();
                if (Accion == 1)
                {
                    CW_DisponibilidadMedica VisorHistoria = new CW_DisponibilidadMedica();
                    VisorHistoria.UnidadReplicacion = tipoDocumento;
                    VisorHistoria.CMP = Documento;
                    VisorHistoria.IdHorario = 1;
                    VisorHistoria.IdEspecialidad_Nombre = cod_sucursal;
                    var lst = new List<A_SP_SS_HCE_VisorHistoria_Result>();
                    List<VW_SS_HCE_VisorAnamnesis> lstAnamnesis = new List<VW_SS_HCE_VisorAnamnesis>();
                    List<VW_SS_HCE_VisorDiagnostico> lstDiagnostico = new List<VW_SS_HCE_VisorDiagnostico>();
                    List<VW_SS_HCE_VisorExamen> lstExamen = new List<VW_SS_HCE_VisorExamen>();
                    List<VW_SS_HCE_VisorReceta> lstReceta = new List<VW_SS_HCE_VisorReceta>();

                    lst = m.getOas(Documento, FechaInicio, FechaFin, cod_sucursal);
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(lst);
                    jsonString = jsonString.Replace("\n", "");
                    jsonString = Regex.Replace(jsonString, @"[^\u0000-\u007F]+", string.Empty);
                    return Content(jsonString, "application/json");
                }
                else
                {
                    return Json("Error: Valores de Parametro ", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception exception)
            {            
                string dd = exception.Source;
                BaseDatos.WriteLog(System.DateTime.Now + " | " + "Error Asignacion: EXEC A_SP_SS_HCE_VisorHistoria  '" + FechaInicio + "' ,'" + FechaFin + "','" + Documento + "','" + cod_sucursal +"' | " + exception.StackTrace + " | " + dd);
                return Json("Error : " + " | " + exception.StackTrace, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ListarVisorHistoriaId(Nullable<int> Accion, string tipoDocumento, string Documento, string IdOrdenAtencion, string cod_sucursal)
        {

            Nullable<int> IdOrden = null;
            Nullable<int> Linea = null;

            if (IdOrdenAtencion.Length > 0)
            {
                IdOrden = Convert.ToInt32(IdOrdenAtencion);
            }
            if (tipoDocumento.Length > 0)
            {
                Linea = Convert.ToInt32(tipoDocumento.ToString());
            }
            try
            {
                List<CW_VisorHistoria> lstSalida = new List<CW_VisorHistoria>();
                if (Accion == 3)
                {
                    CW_DisponibilidadMedica VisorHistoria = new CW_DisponibilidadMedica();
                    VisorHistoria.CMP = Documento;
                    VisorHistoria.IdHorario = 3;
                    VisorHistoria.IdCita = IdOrden;
                    VisorHistoria.IdTurno = Linea;
                    VisorHistoria.IdEspecialidad_Nombre = cod_sucursal;

                    List<VW_SS_HCE_VisorHistoria> lst = new List<VW_SS_HCE_VisorHistoria>();
                    List<VW_SS_HCE_VisorAnamnesis> lstAnamnesis = new List<VW_SS_HCE_VisorAnamnesis>();
                    List<VW_SS_HCE_VisorDiagnostico> lstDiagnostico = new List<VW_SS_HCE_VisorDiagnostico>();
                    List<VW_SS_HCE_VisorExamen> lstExamen = new List<VW_SS_HCE_VisorExamen>();
                    List<VW_SS_HCE_VisorReceta> lstReceta = new List<VW_SS_HCE_VisorReceta>();
                    List<VW_SS_HCE_VisorDescansoMedico> lstDescansoMedico = new List<VW_SS_HCE_VisorDescansoMedico>();
                    List<VW_SS_HCE_VisorProcedimiento> lstProcedimiento = new List<VW_SS_HCE_VisorProcedimiento>();
                    //  pObjVisor.list_VW_SS_HCE_VisorExamen = m.getDiagnostico(pObjVisor.IdOrdenAtencion, IdEspe).ToList();

                    lst = m.HCE_VisorHistoria(VisorHistoria);
                    if (lst.Count>0)
                    {
                        lstAnamnesis = m.HCE_VisorHistoria_Anamnesis(VisorHistoria);
                        lstDiagnostico = m.HCE_VisorHistoria_Diagnostico(VisorHistoria);
                        lstExamen = m.HCE_VisorHistoria_Examen(VisorHistoria);
                        lstReceta = m.HCE_VisorHistoria_Receta(VisorHistoria);
                        lstDescansoMedico = m.HCE_VisorHistoria_DescansoMedico(VisorHistoria);
                        lstProcedimiento = m.HCE_VisorHistoria_Procedimiento(VisorHistoria);
                    }               

                    foreach (VW_SS_HCE_VisorHistoria intobj2 in lst)
                    {
                        CW_VisorHistoria pObjVisor = new CW_VisorHistoria();
                        pObjVisor.CitaTipo = intobj2.CitaTipo;
                        pObjVisor.CitaFecha = intobj2.CitaFecha;
                        pObjVisor.CitaHora = intobj2.CitaHora;
                        pObjVisor.Origen = intobj2.Origen;
                        pObjVisor.NombreEspecialidad = intobj2.NombreEspecialidad;
                        pObjVisor.TipoPacienteNombre = intobj2.TipoPacienteNombre;
                        pObjVisor.CodigoOA = intobj2.CodigoOA;
                        pObjVisor.Cama = intobj2.Cama;
                        pObjVisor.FechaInicio = intobj2.FechaInicio;
                        pObjVisor.TipoOrdenAtencionNombre = intobj2.TipoOrdenAtencionNombre;
                        pObjVisor.CodigoHC = intobj2.CodigoHC;
                        pObjVisor.CodigoHCAnterior = intobj2.CodigoHCAnterior;
                        pObjVisor.PacienteNombre = intobj2.PacienteNombre;
                        pObjVisor.MedicoNombre = intobj2.MedicoNombre;
                        pObjVisor.IdOrdenAtencion = intobj2.IdOrdenAtencion;
                        pObjVisor.LineaOrdenAtencion = intobj2.LineaOrdenAtencion;
                        pObjVisor.Aseguradora = intobj2.Aseguradora;
                        pObjVisor.IdHospitalizacion = intobj2.IdHospitalizacion;
                        pObjVisor.LineaHospitalizacion = intobj2.LineaHospitalizacion;
                        pObjVisor.IdConsultaExterna = intobj2.IdConsultaExterna;
                        pObjVisor.IdProcedimiento = intobj2.IdProcedimiento;
                        pObjVisor.Modalidad = intobj2.Modalidad;
                        pObjVisor.IndicadorSeguro = intobj2.IndicadorSeguro;
                        pObjVisor.IdCita = intobj2.IdCita;
                        pObjVisor.FechaFin = intobj2.FechaFin;  
                        pObjVisor.TipoPaciente = intobj2.TipoPaciente;
                        pObjVisor.TipoAtencion = intobj2.TipoAtencion;
                        pObjVisor.IdEspecialidad = intobj2.IdEspecialidad;             
                        pObjVisor.TipoOrdenAtencion = intobj2.TipoOrdenAtencion;
                        pObjVisor.Componente = intobj2.Componente;
                        pObjVisor.ComponenteNombre = intobj2.ComponenteNombre;
                        pObjVisor.Compania = intobj2.Compania;
                        pObjVisor.Sucursal = intobj2.Sucursal;              
                        pObjVisor.UnidadReplicacionHCE = intobj2.UnidadReplicacionHCE;
                        pObjVisor.EstadoEpiAtencion = intobj2.EstadoEpiAtencion;                    
                        pObjVisor.SecuenciaHCE = intobj2.SecuenciaHCE;                    
                        pObjVisor.sexo = intobj2.sexo;
                        pObjVisor.FechaNacimiento = intobj2.FechaNacimiento;
                        pObjVisor.EstadoCivil = intobj2.EstadoCivil;
                        pObjVisor.NivelInstruccion = intobj2.NivelInstruccion;
                        pObjVisor.Direccion = intobj2.Direccion;
                        pObjVisor.TipoDocumento = intobj2.TipoDocumento;
                        pObjVisor.Documento = intobj2.Documento;
                        pObjVisor.ApellidoPaterno = intobj2.ApellidoPaterno;
                        pObjVisor.ApellidoMaterno = intobj2.ApellidoMaterno;
                        pObjVisor.Nombres = intobj2.Nombres;
                        pObjVisor.LugarNacimiento = intobj2.LugarNacimiento;
                        pObjVisor.CodigoPostal = intobj2.CodigoPostal;
                        pObjVisor.Provincia = intobj2.Provincia;
                        pObjVisor.Departamento = intobj2.Departamento;
                        pObjVisor.Telefono = intobj2.Telefono;
                        pObjVisor.CorreoElectronico = intobj2.CorreoElectronico;
                        pObjVisor.EsPaciente = intobj2.EsPaciente;
                        pObjVisor.EsEmpresa = intobj2.EsEmpresa;
                        pObjVisor.Pais = intobj2.Pais;
                        pObjVisor.EstadoPersona = intobj2.EstadoPersona;
                        pObjVisor.UnidadReplicacionEC = intobj2.UnidadReplicacionEC;
                        pObjVisor.TipoAtencionDescX = intobj2.TipoAtencionDescX;
                        pObjVisor.list_VW_SS_HCE_VisorAnamnesis = lstAnamnesis.Where(o => o.IdOrdenAtencion == pObjVisor.IdOrdenAtencion && o.LineaOrdenAtencion == pObjVisor.LineaOrdenAtencion).ToList();
                        pObjVisor.list_VW_SS_HCE_VisorDiagnostico = lstDiagnostico.Where(o => o.IdOrdenAtencion == pObjVisor.IdOrdenAtencion && o.LineaOrdenAtencion == pObjVisor.LineaOrdenAtencion).ToList();
                        if (!string.IsNullOrEmpty(intobj2.IdConsultaExterna.ToString()))
                        {
                            pObjVisor.list_VW_SS_HCE_VisorReceta = lstReceta.Where(o => o.IdOrdenAtencion == pObjVisor.IdOrdenAtencion && o.IdConsultaExterna == pObjVisor.IdConsultaExterna).ToList();
                            pObjVisor.list_VW_SS_HCE_VisorExamen = lstExamen.Where(o => o.IdOrdenAtencion == pObjVisor.IdOrdenAtencion && o.IdConsultaExterna == pObjVisor.IdConsultaExterna).ToList();
                            pObjVisor.list_VW_SS_HCE_VisorDescansoMedico = lstDescansoMedico.Where(o => o.IdOrdenAtencion == pObjVisor.IdOrdenAtencion && o.IdConsultaExterna == pObjVisor.IdConsultaExterna).ToList();
                        }
                        else
                        {
                            pObjVisor.list_VW_SS_HCE_VisorExamen = lstExamen.Where(o => o.IdOrdenAtencion == pObjVisor.IdOrdenAtencion && o.Linea == pObjVisor.LineaOrdenAtencion).ToList();
                            pObjVisor.list_VW_SS_HCE_VisorReceta = lstReceta.Where(o => o.IdOrdenAtencion == pObjVisor.IdOrdenAtencion && o.LineaOrdenAtencion == pObjVisor.LineaOrdenAtencion).ToList();
                             if (!string.IsNullOrEmpty(intobj2.IdProcedimiento.ToString()))
                                {
                                    pObjVisor.list_VW_SS_HCE_VisorProcedimiento = lstProcedimiento.Where(o => o.IdOrdenAtencion == pObjVisor.IdOrdenAtencion && o.LineaOrdenAtencion == pObjVisor.LineaOrdenAtencion).ToList();
                                } 
                        }
                        lstSalida.Add(pObjVisor);
                    }
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(lstSalida);
                    jsonString = jsonString.Replace("\n", "");
                    jsonString = Regex.Replace(jsonString, @"[^\u0000-\u007F]+", string.Empty);
                    return Content(jsonString, "application/json");
                }
                else
                {
                    return Json("Error: Valores de Parametro ", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception exception)
            {
                //lst = context.VW_SS_HCE_VisorHistoria.Where(
                //        t =>   t.Documento == Disponibilidad.CMP &&
                //            t.IdOrdenAtencion == Disponibilidad.IdCita && t.LineaOrdenAtencion == Disponibilidad.IdTurno && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre)
               
                string dd = exception.Source;
                BaseDatos.WriteLog(System.DateTime.Now + " | " + "Error Asignacion: SELECT * FROM CW_VisorHistoria WHERE tipoDocumento= '" + tipoDocumento + "' AND Documento='" + Documento + "' AND Sucursal='" + cod_sucursal + "' | " + exception.StackTrace + " | " + dd);
                return Json("Error : " + " | " + exception.StackTrace, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion

    }
}
