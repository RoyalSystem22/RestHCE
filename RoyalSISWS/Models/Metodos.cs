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
        
        public List<SP_VW_ATENCIONPACIENTE_LISTAR_Result> listarAtencionesPacienteHCE(SP_VW_ATENCIONPACIENTE_LISTAR_Result objSC)
        {
            List<SP_VW_ATENCIONPACIENTE_LISTAR_Result> objLista = new List<SP_VW_ATENCIONPACIENTE_LISTAR_Result>();
            using (var context = new WEB_ERPSALUDEntities())
            {
                objLista = context.SP_VW_ATENCIONPACIENTE_LISTAR(
                objSC.UnidadReplicacion, objSC.IdEpisodioAtencion, objSC.UnidadReplicacionEC, objSC.IdPaciente, objSC.EpisodioClinico, objSC.IdEstablecimientoSalud,
                objSC.IdUnidadServicio, objSC.IdPersonalSalud, objSC.IdPersonalSalud, objSC.EpisodioAtencion, 
                objSC.FechaRegistro, objSC.FechaAtencion, objSC.TipoAtencion,objSC.IdOrdenAtencion, objSC.LineaOrdenAtencion, objSC.TipoOrdenAtencion, objSC.Estado, 
                objSC.UsuarioModificacion, objSC.FechaModificacion,objSC.IdEspecialidad, objSC.CodigoOA,objSC.FechaOrden, objSC.IdProcedimiento, 
                objSC.IdTipoOrden, objSC.FechaRegistroEpiClinico, objSC.FechaCierreEpiClinico,objSC.TipoPaciente ,objSC.Edad, objSC.CodigoHC, objSC.CodigoHCAnterior,
                objSC.CodigoHCSecundario, objSC.TipoHistoria, objSC.EstadoPaciente,objSC.NumeroFile, objSC.IDPACIENTE_OK, objSC.Persona, objSC.NombreCompleto, 
                objSC.TipoDocumento, objSC.Documento, objSC.EsCliente, objSC.EsProveedor, objSC.EsEmpleado,  objSC.EsOtro, objSC.TipoPersona, objSC.FechaNacimiento,
                objSC.Sexo, objSC.Nacionalidad, objSC.EstadoCivil, objSC.NivelInstruccion ,objSC.CodigoPostal,  objSC.Provincia, objSC.Departamento,
                objSC.FecIniDiscamec, objSC.FecFinDiscamec, objSC.Pais, objSC.EsPaciente, objSC.EsEmpresa, objSC.personanew, objSC.EstadoPersona, objSC.Servicio,
                0, 0, objSC.Version, objSC.Accion).ToList();
            }
            return objLista;
        }

        #endregion
    }
}