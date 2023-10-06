using RoyalSISWS.Models.Entidades;
using RoyalSISWS.Models.SpringSalud_produccion;
using RoyalSISWS.Models.WEB_ERPSALUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Transactions;

namespace RoyalSISWS.Models
{
    public class Metodos
    {

        #region Historia

        public List<A_SP_SS_HCE_VisorHistoria_Result> getOas(String documento, DateTime FechaInicio, DateTime FechaFin, string cod_sucursal)
        {
            //ProductoPaginacion p = new ProductoPaginacion();
            using (var context = new SpringSalud_produccionEntities())
            {
                return context.A_SP_SS_HCE_VisorHistoria(FechaInicio, FechaFin, documento, cod_sucursal).OrderByDescending(s => s.FechaInicio).ToList();
            }
        }

        public List<A_SP_SS_HCE_ListaServiciosAuxiliares_Result> getDiagnostico(int IdOrdenAtencion, int IdEspecialidad)
        {
            using (var context = new SpringSalud_produccionEntities())
            {
                return context.A_SP_SS_HCE_ListaServiciosAuxiliares(IdOrdenAtencion, IdEspecialidad).ToList();
            }
        }

        public List<VW_SS_HCE_VisorHistoria> HCE_VisorHistoria(CW_DisponibilidadMedica Disponibilidad)
        {
            List<VW_SS_HCE_VisorHistoria> lst = new List<VW_SS_HCE_VisorHistoria>();
            using (SpringSalud_produccionEntities context = new SpringSalud_produccionEntities())
            {
                context.Database.Connection.Open();
                if (Disponibilidad.IdHorario == 1)
                {
                    lst = context.VW_SS_HCE_VisorHistoria.Where(
                        t => t.TipoDocumento == Disponibilidad.UnidadReplicacion && t.Documento == Disponibilidad.CMP && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).OrderByDescending(s => s.FechaInicio).AsNoTracking().ToList();
                }

                if (Disponibilidad.IdHorario == 2)
                {
                    //lst = context.VW_SS_HCE_VisorHistoria.Where( t => t.IdMedico == Disponibilidad.IdMedico &&
                    //    t.FechaInicio >= Disponibilidad.FechaInicio && t.FechaFin <= Disponibilidad.FechaInicio).ToList();

                    lst = context.VW_SS_HCE_VisorHistoria.Where(t => t.IdMedico == Disponibilidad.IdMedico && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).OrderByDescending(s => s.FechaInicio).AsNoTracking().ToList();
                }
                if (Disponibilidad.IdHorario == 3)
                {
                    lst = context.VW_SS_HCE_VisorHistoria.Where(
                        t => //t.TipoDocumento == Disponibilidad.UnidadReplicacion && 
                            t.Documento == Disponibilidad.CMP &&
                            t.IdOrdenAtencion == Disponibilidad.IdCita && t.LineaOrdenAtencion == Disponibilidad.IdTurno && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).OrderByDescending(s => s.FechaInicio).AsNoTracking().ToList();
                }
                context.Database.Connection.Close();
                context.Dispose();
            }
            return lst;
        }

        public List<VW_SS_HCE_VisorExamen> HCE_VisorHistoria_Examen(CW_DisponibilidadMedica Disponibilidad)
        {
            List<VW_SS_HCE_VisorExamen> lst = new List<VW_SS_HCE_VisorExamen>();
            using (SpringSalud_produccionEntities context = new SpringSalud_produccionEntities())
            {
                context.Database.Connection.Open();
                if (Disponibilidad.IdHorario == 1)
                {
                    lst = context.VW_SS_HCE_VisorExamen.Where(
                        t => t.tipodocumento == Disponibilidad.UnidadReplicacion && t.documento == Disponibilidad.CMP && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                if (Disponibilidad.IdHorario == 3)
                {
                    lst = context.VW_SS_HCE_VisorExamen.Where(
                        t =>
                            t.documento == Disponibilidad.CMP && t.IdOrdenAtencion == Disponibilidad.IdCita && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                context.Database.Connection.Close();
                context.Dispose();
            }
            return lst;
        }

        public List<VW_SS_HCE_VisorAnamnesis> HCE_VisorHistoria_Anamnesis(CW_DisponibilidadMedica Disponibilidad)
        {
            List<VW_SS_HCE_VisorAnamnesis> lst = new List<VW_SS_HCE_VisorAnamnesis>();
            using (SpringSalud_produccionEntities context = new SpringSalud_produccionEntities())
            {
                context.Database.Connection.Open();
                if (Disponibilidad.IdHorario == 1)
                {
                    lst = context.VW_SS_HCE_VisorAnamnesis.Where(
                    t => t.TipoInforme == "CE" && t.tipodocumento == Disponibilidad.UnidadReplicacion && t.documento == Disponibilidad.CMP
                        && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                if (Disponibilidad.IdHorario == 2)
                {
                    lst = context.VW_SS_HCE_VisorAnamnesis.Where(
                        //t => t.Medico == Disponibilidad.IdMedico && t.FechaCreacion == Disponibilidad.FechaInicio).ToList();
                      t => t.FechaCreacion == Disponibilidad.FechaInicio && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                if (Disponibilidad.IdHorario == 3)
                {
                    lst = context.VW_SS_HCE_VisorAnamnesis.Where(
                    t => t.TipoInforme == "CE" && //t.tipodocumento == Disponibilidad.UnidadReplicacion && 
                        t.documento == Disponibilidad.CMP &&
                            t.IdOrdenAtencion == Disponibilidad.IdCita && t.LineaOrdenAtencion == Disponibilidad.IdTurno && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                context.Database.Connection.Close();
                context.Dispose();
            }
            return lst;
        }

        public List<VW_SS_HCE_VisorDiagnostico> HCE_VisorHistoria_Diagnostico(CW_DisponibilidadMedica Disponibilidad)
        {
            List<VW_SS_HCE_VisorDiagnostico> lst = new List<VW_SS_HCE_VisorDiagnostico>();
            using (SpringSalud_produccionEntities context = new SpringSalud_produccionEntities())
            {
                context.Database.Connection.Open();
                if (Disponibilidad.IdHorario == 1)
                {
                    lst = context.VW_SS_HCE_VisorDiagnostico.Where(
                        t => t.tipodocumento == Disponibilidad.UnidadReplicacion && t.documento == Disponibilidad.CMP && t.UsuarioModificacion == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                if (Disponibilidad.IdHorario == 2)
                {
                    lst = context.VW_SS_HCE_VisorDiagnostico.Where(
                        t => t.FechaCreacion == Disponibilidad.FechaInicio && t.UsuarioModificacion == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                if (Disponibilidad.IdHorario == 3)
                {
                    lst = context.VW_SS_HCE_VisorDiagnostico.Where(
                         t => //t.tipodocumento == Disponibilidad.UnidadReplicacion && 
                             t.documento == Disponibilidad.CMP &&
                         t.IdOrdenAtencion == Disponibilidad.IdCita && t.LineaOrdenAtencion == Disponibilidad.IdTurno && t.UsuarioModificacion == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                context.Database.Connection.Close();
                context.Dispose();
            }
            return lst;
        }

        public List<VW_SS_HCE_VisorReceta> HCE_VisorHistoria_Receta(CW_DisponibilidadMedica Disponibilidad)
        {
            List<VW_SS_HCE_VisorReceta> lst = new List<VW_SS_HCE_VisorReceta>();
            using (SpringSalud_produccionEntities context = new SpringSalud_produccionEntities())
            {
                context.Database.Connection.Open();
                if (Disponibilidad.IdHorario == 1)
                {
                    lst = context.VW_SS_HCE_VisorReceta.Where(
                        t => t.tipodocumento == Disponibilidad.UnidadReplicacion && t.documento == Disponibilidad.CMP && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                if (Disponibilidad.IdHorario == 2)
                {
                    lst = context.VW_SS_HCE_VisorReceta.Where(
                        t => t.FechaCreacion == Disponibilidad.FechaInicio && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                if (Disponibilidad.IdHorario == 3)
                {
                    lst = context.VW_SS_HCE_VisorReceta.Where(
                        t => //t.tipodocumento == Disponibilidad.UnidadReplicacion && 
                            t.documento == Disponibilidad.CMP && t.IdOrdenAtencion == Disponibilidad.IdCita && t.Sucursal == Disponibilidad.IdEspecialidad_Nombre).AsNoTracking().ToList();
                }
                context.Database.Connection.Close();
                context.Dispose();
            }
            return lst;
        }

        public List<VW_SS_HCE_VisorProcedimientoInforme> HCE_VisorInformes(CW_DisponibilidadMedica Disponibilidad)
        {
            List<VW_SS_HCE_VisorProcedimientoInforme> lst = new List<VW_SS_HCE_VisorProcedimientoInforme>();
            using (SpringSalud_produccionEntities context = new SpringSalud_produccionEntities())
            {
                context.Database.Connection.Open();
                if (Disponibilidad.IdHorario == 1)
                {
                    lst = context.VW_SS_HCE_VisorProcedimientoInforme.Where(
                        t => t.tipodocumento == Disponibilidad.UnidadReplicacion && t.documento == Disponibilidad.CMP).AsNoTracking().ToList();
                }
                if (Disponibilidad.IdHorario == 3)
                {
                    lst = context.VW_SS_HCE_VisorProcedimientoInforme.Where(
                        t => //t.tipodocumento == Disponibilidad.UnidadReplicacion && 
                            t.documento == Disponibilidad.CMP &&
                        t.IdOrdenAtencion == Disponibilidad.IdCita && t.Linea == Disponibilidad.IdTurno).AsNoTracking().ToList();
                }
                context.Database.Connection.Close();
                context.Dispose();
            }
            return lst;
        }

        public List<VW_SS_HCE_VisorEmergencia> HCE_VisoreEmergencia(CW_DisponibilidadMedica Disponibilidad)
        {
            List<VW_SS_HCE_VisorEmergencia> lst = new List<VW_SS_HCE_VisorEmergencia>();
            using (SpringSalud_produccionEntities context = new SpringSalud_produccionEntities())
            {
                context.Database.Connection.Open();
                if (Disponibilidad.IdTurno == 1)
                {
                    lst = context.VW_SS_HCE_VisorEmergencia.Where(
                        t => t.Origen == Disponibilidad.UnidadReplicacion && t.CodigoOA == Disponibilidad.CMP).AsNoTracking().ToList();
                }
                context.Database.Connection.Close();
                context.Dispose();
            }
            return lst;
        }

        #endregion


        #region Metodobdhce
        public List<SP_ParametrosMastListar_Result> listarParametro(SP_ParametrosMastListar_Result objSC, int inicio, int final)
        {
            List<SP_ParametrosMastListar_Result> objLista = new List<SP_ParametrosMastListar_Result>();
            using (var context = new WEB_ERPSALUDEntities())
            {
                objLista = context.SP_ParametrosMastListar(objSC.CompaniaCodigo, objSC.AplicacionCodigo, objSC.ParametroClave,
                  objSC.DescripcionParametro, objSC.Explicacion, objSC.TipodeDatoFlag, objSC.Texto,
                  objSC.Numero, objSC.Fecha, objSC.FinanceComunFlag, objSC.Estado,
                  objSC.UltimoUsuario, objSC.UltimaFechaModif, objSC.ExplicacionAdicional, objSC.Texto1, objSC.Texto2,
                  objSC.UnidadReplicacion, objSC.Accion, inicio, final, objSC.UsuarioCreacion, objSC.FechaCreacion
                 ).ToList();
            }
            return objLista;
        }

        public List<SS_HC_InformeConsultaExterna_FE> InformeConsultaExternaListar(SS_HC_InformeConsultaExterna_FE objSC)
        {
            List<SS_HC_InformeConsultaExterna_FE> objLista = new List<SS_HC_InformeConsultaExterna_FE>();
            using (var context = new WEB_ERPSALUDEntities())
            {
                List<SS_HC_InformeConsultaExterna_FE> objConsultas = (from t in context.SS_HC_InformeConsultaExterna_FE
                                                                      where
                                                                      t.UnidadReplicacion == objSC.UnidadReplicacion
                                                                      && t.IdPaciente == objSC.IdPaciente
                                                                      && t.EpisodioClinico == objSC.EpisodioClinico
                                                                      && t.IdEpisodioAtencion == objSC.IdEpisodioAtencion
                                                                      orderby t.IdEpisodioAtencion descending
                                                                      select t).ToList();

                if (objConsultas != null)
                {
                    objLista.AddRange(objConsultas);
                }

            }
            return objLista;
        }

        public ViewResponse HC_InformeConsultaExternaMantenimiento(Nullable<int> Accion, string Objeto)
        {
            ViewResponse obje = new ViewResponse();
            using (var context = new WEB_ERPSALUDEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        SS_IT_SaludOFTALMOLOGICOIngreso objSC = (SS_IT_SaludOFTALMOLOGICOIngreso)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(SS_IT_SaludOFTALMOLOGICOIngreso));

                        SS_HC_InformeConsultaExterna_FE objSave = new SS_HC_InformeConsultaExterna_FE();
                        objSave.UnidadReplicacion = objSC.UnidadReplicacion;
                        objSave.IdPaciente = objSC.IdPaciente;
                        objSave.EpisodioClinico = (int)objSC.EpisodioClinico;
                        objSave.IdEpisodioAtencion = objSC.IdEpisodioAtencion;
                        objSave.Observacion = objSC.ENFACTUAL;
                        objSave.Version = "CCEPF330";
                        objSave.Estado = objSC.Estado;
                        objSave.UsuarioModificacion = objSC.UsuarioCreacion;
                        objSave.UsuarioModificacion = objSC.UsuarioModificacion;
                        objSave.FechaCreacion = objSC.FechaCreacion;
                        objSave.FechaModificacion = objSC.FechaModificacion;
                        if (Accion == 1)
                        {
                            objSave.Accion = "NUEVO";
                            context.Entry(objSave).State = EntityState.Added;
                            obje.valor = context.SaveChanges();
                            obje.ok = true;
                            obje.msg = "Se registro Correcto";
                        }
                        if (Accion == 2)
                        {
                            objSave.Accion = "UPDATE";
                            context.Entry(objSave).State = EntityState.Modified;
                            obje.valor = context.SaveChanges();
                            obje.ok = true;
                            obje.msg = "Se actualizo Correctamente";
                        }                
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                        obje.ok = true;
                        obje.valor = 0;
                    }
                }
            }
            return obje;
        }
      
        #endregion


        #region MetodoMirth

        public ViewResponse Mirth_DiagnosticoIngresoMantenimiento(Nullable<int> Accion, string Objeto)
        {
            ViewResponse obje = new ViewResponse();
            using (var context = new SpringSalud_produccionEntities())
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                    try
                    {
                       // SS_IT_SaludDiagnosticoIngreso objSC = (SS_IT_SaludDiagnosticoIngreso)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(SS_IT_SaludDiagnosticoIngreso));
                        List<SS_IT_SaludDiagnosticoIngreso> LstEntyt = (List<SS_IT_SaludDiagnosticoIngreso>)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(List<SS_IT_SaludDiagnosticoIngreso>));
                        foreach (SS_IT_SaludDiagnosticoIngreso objSC in LstEntyt)
                        {         
                            var VAAA = context.SP_SS_IT_SaludDiagnosticoIngreso(objSC.UnidadReplicacion, objSC.IdEpisodioAtencion, objSC.IdPaciente, objSC.EpisodioClinico,
                             objSC.IdOrdenAtencion, objSC.LineaOrdenAtencionConsulta, objSC.IdDiagnostico, objSC.Secuencia, objSC.Determinacion, objSC.TIPOORDENATENCION,
                             objSC.ObservacionDIAGNOSTICO, objSC.TIPOIT, objSC.Estado, objSC.UsuarioCreacion, objSC.FechaCreacion);
                        }
                        obje.msg = "Correcto";
                        obje.ok = true;
                        obje.valor = LstEntyt.Count;                          
                    }
                    catch (Exception ex)
                    {
                        obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                        obje.ok = false;
                        obje.valor = 0;
                    }
                //}
            }
            return obje;
        }

        public ViewResponse SaludRecetaIndicacionesGENIngresoMantenimiento(Nullable<int> Accion, string Objeto)
        {
            ViewResponse obje = new ViewResponse();
            using (var context = new SpringSalud_produccionEntities())
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                try
                {
                    // SS_IT_SaludDiagnosticoIngreso objSC = (SS_IT_SaludDiagnosticoIngreso)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(SS_IT_SaludDiagnosticoIngreso));
                    SS_IT_SaludRecetaIndicacionesGENIngreso objSC = (SS_IT_SaludRecetaIndicacionesGENIngreso)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(SS_IT_SaludRecetaIndicacionesGENIngreso));

                    var VAAA = context.SP_SS_IT_SaludRecetaIndicacionesGENIngreso(objSC.UnidadReplicacion, objSC.IdEpisodioAtencion, objSC.IdPaciente, objSC.EpisodioClinico,
                         objSC.IdOrdenAtencion, objSC.LineaOrdenAtencionConsulta, objSC.TipoIndicacion, objSC.Descripcion, objSC.Secuencia, objSC.Estado, objSC.UsuarioCreacion, objSC.FechaCreacion);
                    
                    obje.msg = "Correcto";
                    obje.ok = true;
                    obje.valor = 1;
                }
                catch (Exception ex)
                {
                    obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                    obje.ok = false;
                    obje.valor = 0;
                }
                //}
            }
            return obje;
        }
        
        public ViewResponse SaludRecetaIngresoMantenimiento(Nullable<int> Accion, string Objeto)
        {
            ViewResponse obje = new ViewResponse();
            using (var context = new SpringSalud_produccionEntities())
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                try
                {
                    List<SS_IT_SaludRecetaIngreso> LstEntyt = (List<SS_IT_SaludRecetaIngreso>)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(List<SS_IT_SaludRecetaIngreso>));
                    foreach (SS_IT_SaludRecetaIngreso objSC in LstEntyt)
                    {
                        var VAAA = context.SP_SS_IT_SaludRecetaIngreso(objSC.UnidadReplicacion, objSC.IdEpisodioAtencion, objSC.IdPaciente, objSC.EpisodioClinico,
                         objSC.IdOrdenAtencion, objSC.LineaOrdenAtencionConsulta, objSC.Secuencia, objSC.Componente, objSC.SubFamilia, objSC.Familia, objSC.Linea,
                         objSC.UnidadMedida, objSC.Cantidad, objSC.Via, objSC.Dosis, objSC.DiasTratamiento, objSC.Frecuencia, objSC.IndicadorEPS, objSC.TipoReceta,
                         objSC.INDICACIONESPECIFICA, objSC.TipoOrdenAtencion, objSC.SECUENCIALHCE, objSC.Estado, objSC.UsuarioCreacion, objSC.FechaCreacion);
                    }          
                    obje.msg = "Correcto";
                    obje.ok = true;
                    obje.valor = 1;
                }
                catch (Exception ex)
                {
                    obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                    obje.ok = false;
                    obje.valor = 0;
                }
                //}
            }
            return obje;
        }

        public ViewResponse Mirth_ProcedimientoIngresoMantenimiento(Nullable<int> Accion, string Objeto)
        {
            ViewResponse obje = new ViewResponse();
            using (var context = new SpringSalud_produccionEntities())
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                try
                {
                    List<SS_IT_SaludProcedimientoIngreso> LstEntyt = (List<SS_IT_SaludProcedimientoIngreso>)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(List<SS_IT_SaludProcedimientoIngreso>));
                    foreach (SS_IT_SaludProcedimientoIngreso objSC in LstEntyt)
                    {
                        var VAAA = context.SP_SS_IT_SaludProcedimientoIngreso(objSC.UnidadReplicacion, objSC.IdEpisodioAtencion, objSC.IdPaciente, objSC.EpisodioClinico,
                      objSC.IdOrdenAtencion, objSC.LineaOrdenAtencionConsulta, objSC.Componente, objSC.Secuencia, objSC.idtipoordenatencion, objSC.Cantidad,
                      objSC.IndicadorEPS, objSC.IdMedico, objSC.Especialidad, objSC.IdCita, objSC.Observacion, objSC.SecuencialHCE,
                      objSC.EstadoDocumento, objSC.Estado, objSC.UsuarioCreacion, objSC.FechaCreacion);
                    }
                                       

                    obje.msg = "Correcto";
                    obje.ok = true;
                    obje.valor = 1;
                    //scope.Complete();
                }
                catch (Exception ex)
                {
                    obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                    obje.ok = true;
                    obje.valor = 0;
                }
                //}
            }
            return obje;
        }

        public ViewResponse SaludInformeRutaIngresoMantenimiento(Nullable<int> Accion, string Objeto)
        {
            ViewResponse obje = new ViewResponse();
            using (var context = new SpringSalud_produccionEntities())
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                try
                {
                    List<SS_IT_SaludInformeRutaIngreso> LstEntyt = (List<SS_IT_SaludInformeRutaIngreso>)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(List<SS_IT_SaludInformeRutaIngreso>));
                    foreach (SS_IT_SaludInformeRutaIngreso objSC in LstEntyt)
                    {
                        var VAAA = context.SP_SS_IT_SaludInformeRutaIngreso(objSC.UnidadReplicacion, objSC.IdEpisodioAtencion, objSC.IdPaciente, objSC.EpisodioClinico,
                         objSC.IdOrdenAtencion, objSC.LineaOrdenAtencion, objSC.RutaInforme, objSC.Observacion,
                          objSC.Estado, objSC.UsuarioCreacion, objSC.FechaCreacion);
                    }          
                    obje.msg = "Correcto";
                    obje.ok = true;
                    obje.valor = 1;
                }
                catch (Exception ex)
                {
                    obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                    obje.ok = false;
                    obje.valor = 0;
                }
                //}
            }
            return obje;
        }

        public ViewResponse SaludInformePROCIngresoMantenimiento(Nullable<int> Accion, string Objeto)
        {
            ViewResponse obje = new ViewResponse();
            using (var context = new SpringSalud_produccionEntities())
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                try
                {
                    SS_IT_SaludInformePROCIngreso objSC = (SS_IT_SaludInformePROCIngreso)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(SS_IT_SaludInformePROCIngreso));
                   
                        var VAAA = context.SP_SS_IT_SaludInformePROCIngreso(objSC.UnidadReplicacion, objSC.IdEpisodioAtencion, objSC.IdPaciente, objSC.EpisodioClinico,
                         objSC.IdOrdenAtencion, objSC.LineaOrdenAtencion, objSC.Informe,  objSC.Estado, objSC.UsuarioCreacion, objSC.FechaCreacion);
                          
                    obje.msg = "Correcto";
                    obje.ok = true;
                    obje.valor = 1;
                }
                catch (Exception ex)
                {
                    obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                    obje.ok = false;
                    obje.valor = 0;
                }
                //}
            }
            return obje;
        }
        
        
        public ViewResponse Mirth_OftalmologicoIngresoMantenimiento(Nullable<int> Accion, string Objeto)
        {
            ViewResponse obje = new ViewResponse();
            using (var context = new SpringSalud_produccionEntities())
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                try
                {
                    SS_IT_SaludOFTALMOLOGICOIngreso objSC = (SS_IT_SaludOFTALMOLOGICOIngreso)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(SS_IT_SaludOFTALMOLOGICOIngreso));

                    var VAAA = context.SP_SS_IT_SaludOFTALMOLOGICOIngresoIntermedia(objSC.IdOrdenAtencion,objSC.LineaOrdenAtencion,objSC.UnidadReplicacion,objSC.IdEpisodioAtencion,
                        objSC.IdPaciente,objSC.EpisodioClinico,objSC.Secuencia,objSC.ENFACTUAL,objSC.ANTIMPORTANCIA,objSC.AVscOD,
                        objSC.AvCCOD,objSC.AEAVODPIN,objSC.CERCAVAD,objSC.AVSCOI,objSC.AVCCOI,objSC.AEAVOIDPIN,objSC.CERCAVAOI,objSC.SPHodREFRA,
                        objSC.CILodREFA,objSC.EJEodREFRA,objSC.AVodREFRA,objSC.ADDodREFRA,objSC.DIPodREFRA,objSC.SPHoiSCICLO,objSC.CILoiSCICLO,
                        objSC.EJEoiSCICLO, objSC.AVoiSCICLO, objSC.ADDoiSCICLO, objSC.DIPoiSCICLO, objSC.PAPARPADOSANEXOS, objSC.CORNEACRISTESCLERA,
                        objSC.IRISPUPILA, objSC.TonoOD, objSC.TonoOI, objSC.MMHHTonShiotz, objSC.MMHHTonAplanacion,objSC.MMHHTonOtra,objSC.FONDOJOyG ,
                        objSC.Estado, objSC.UsuarioCreacion, objSC.FechaCreacion);
          
                }
                catch (Exception ex)
                {
                    obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                    obje.ok = true;
                    obje.valor = 0;
                }
                //}
            }
            return obje;
        }

        public ViewResponse Mirth_AnamnesisInFormeMedicoMantenimiento(Nullable<int> Accion, SS_IT_SaludOFTALMOLOGICOIngreso ObjTrace)
        {
            System.Nullable<int> iReturnValue;
            ViewResponse obje = new ViewResponse();
            using (var context = new SpringSalud_produccionEntities())
            {
                context.Database.Connection.Open();
                //using (TransactionScope scope = new TransactionScope())
                //{
                try
                {
                    if (Accion == 1)
                    {
                        var VAAA = context.SP_SS_IT_SALUDAnamnesisInFormeMedico(ObjTrace.IdOrdenAtencion, ObjTrace.IdPaciente,
                              ObjTrace.LineaOrdenAtencion, 1, ObjTrace.ENFACTUAL, ObjTrace.Estado, ObjTrace.UsuarioCreacion,
                           ObjTrace.FechaCreacion, "", ObjTrace.UsuarioModificacion, DateTime.Now);
                        //  obje.valor = int.Parse(VAAA);
                        obje.valor = 1;
                        obje.ok = true;
                        obje.msg = "Se registro Correcto";
                    }
                    //scope.Complete();
                }
                catch (Exception ex)
                {
                    obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                    obje.ok = true;
                    obje.valor = 0;
                }
                context.Database.Connection.Close();
                context.Dispose();
                //}
            }
            return obje;
        }
       
        #endregion
    }
}