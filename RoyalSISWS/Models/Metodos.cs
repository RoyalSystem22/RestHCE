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
                        SS_IT_SaludDiagnosticoIngreso objSC = (SS_IT_SaludDiagnosticoIngreso)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(SS_IT_SaludDiagnosticoIngreso));
                        if (Accion == 1)
                        {
                            context.Entry(objSC).State = EntityState.Added;
                            obje.valor = context.SaveChanges();
                            obje.ok = true;
                            obje.msg = "Se registro Correcto";
                        }
                        if (Accion == 2)
                        {
                            context.Entry(objSC).State = EntityState.Modified;
                            obje.valor = context.SaveChanges();
                            obje.ok = true;
                            obje.msg = "Se actualizo Correctamente";
                        }
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
        
        public ViewResponse Mirth_ProcedimientoIngresoMantenimiento(Nullable<int> Accion, string Objeto)
        {
            ViewResponse obje = new ViewResponse();
            using (var context = new SpringSalud_produccionEntities())
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                try
                {
                    SS_IT_SaludProcedimientoIngreso objSC = (SS_IT_SaludProcedimientoIngreso)Newtonsoft.Json.JsonConvert.DeserializeObject(Objeto, typeof(SS_IT_SaludProcedimientoIngreso));
                    if (Accion == 1)
                    {
                        context.Entry(objSC).State = EntityState.Added;
                        obje.valor = context.SaveChanges();
                        obje.ok = true;
                        obje.msg = "Se registro Correcto";
                    }
                    if (Accion == 2)
                    {
                        context.Entry(objSC).State = EntityState.Modified;
                        obje.valor = context.SaveChanges();
                        obje.ok = true;
                        obje.msg = "Se actualizo Correctamente";
                    }
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
                    if (Accion == 1)
                    {
                        context.Entry(objSC).State = EntityState.Added;
                        obje.valor = context.SaveChanges();
                        obje.ok = true;
                        obje.msg = "Se registro Correcto";
                    }
                    if (Accion == 2)
                    {
                        context.Entry(objSC).State = EntityState.Modified;
                        obje.valor = context.SaveChanges();
                        obje.ok = true;
                        obje.msg = "Se actualizo Correctamente";
                    }
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