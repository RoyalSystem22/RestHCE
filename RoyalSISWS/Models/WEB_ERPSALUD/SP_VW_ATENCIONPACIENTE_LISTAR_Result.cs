//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoyalSISWS.Models.WEB_ERPSALUD
{
    using System;
    
    public partial class SP_VW_ATENCIONPACIENTE_LISTAR_Result
    {
        public string UnidadReplicacion { get; set; }
        public Nullable<long> IdEpisodioAtencion { get; set; }
        public string UnidadReplicacionEC { get; set; }
        public Nullable<int> IdPaciente { get; set; }
        public Nullable<int> EpisodioClinico { get; set; }
        public Nullable<int> IdEstablecimientoSalud { get; set; }
        public Nullable<int> IdUnidadServicio { get; set; }
        public Nullable<int> IdPersonalSalud { get; set; }
        public Nullable<long> EpisodioAtencion { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<System.DateTime> FechaAtencion { get; set; }
        public Nullable<int> TipoAtencion { get; set; }
        public Nullable<int> IdOrdenAtencion { get; set; }
        public Nullable<int> LineaOrdenAtencion { get; set; }
        public Nullable<int> TipoOrdenAtencion { get; set; }
        public Nullable<int> Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdEspecialidad { get; set; }
        public string CodigoOA { get; set; }
        public string ProximaAtencionFlag { get; set; }
        public string IdEspecialidadProxima { get; set; }
        public Nullable<int> IdEstablecimientoSaludProxima { get; set; }
        public Nullable<int> IdTipoInterConsulta { get; set; }
        public Nullable<int> IdTipoReferencia { get; set; }
        public string ObservacionProxima { get; set; }
        public string DescansoMedico { get; set; }
        public Nullable<int> DiasDescansoMedico { get; set; }
        public Nullable<System.DateTime> FechaInicioDescansoMedico { get; set; }
        public Nullable<System.DateTime> FechaFinDescansoMedico { get; set; }
        public Nullable<System.DateTime> FechaOrden { get; set; }
        public Nullable<int> IdProcedimiento { get; set; }
        public string ObservacionOrden { get; set; }
        public Nullable<int> IdTipoOrden { get; set; }
        public string Accion { get; set; }
        public string Version { get; set; }
        public Nullable<System.DateTime> FechaRegistroEpiClinico { get; set; }
        public Nullable<System.DateTime> FechaCierreEpiClinico { get; set; }
        public Nullable<int> TipoPaciente { get; set; }
        public Nullable<int> Edad { get; set; }
        public string Raza { get; set; }
        public string Religion { get; set; }
        public string Cargo { get; set; }
        public string AreaLaboral { get; set; }
        public string Ocupacion { get; set; }
        public string CodigoHC { get; set; }
        public string CodigoHCAnterior { get; set; }
        public string CodigoHCSecundario { get; set; }
        public string TipoAlmacenamiento { get; set; }
        public string TipoHistoria { get; set; }
        public string TipoSituacion { get; set; }
        public Nullable<int> IdUbicacion { get; set; }
        public string LugarProcedencia { get; set; }
        public string RutaFoto { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<int> IndicadorNuevo { get; set; }
        public Nullable<int> EstadoPaciente { get; set; }
        public Nullable<int> NumeroFile { get; set; }
        public string Servicio { get; set; }
        public string UsuarioAlmacenamiento { get; set; }
        public Nullable<System.DateTime> FechaAlmacenamiento { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> IndicadorAsistencia { get; set; }
        public Nullable<int> CantidadAsistencia { get; set; }
        public Nullable<int> UbicacionHHCC { get; set; }
        public Nullable<int> IndicadorMigradoSiteds { get; set; }
        public string NumeroCaja { get; set; }
        public Nullable<int> IndicadorCodigoBarras { get; set; }
        public Nullable<int> IDPACIENTE_OK { get; set; }
        public string CodigoAsegurado { get; set; }
        public Nullable<int> NumeroPoliza { get; set; }
        public string CodigoProducto { get; set; }
        public string CodigoPlan { get; set; }
        public Nullable<int> TipoParentesco { get; set; }
        public string CodigoBeneficio { get; set; }
        public Nullable<int> Situacion { get; set; }
        public Nullable<int> TomoActual { get; set; }
        public Nullable<int> IndicadorHistoriaFisica { get; set; }
        public string DescripcionHistoria { get; set; }
        public Nullable<int> NumeroCertificado { get; set; }
        public Nullable<int> Persona { get; set; }
        public string Origen { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string CodigoBarras { get; set; }
        public string EsCliente { get; set; }
        public string EsProveedor { get; set; }
        public string EsEmpleado { get; set; }
        public string EsOtro { get; set; }
        public string TipoPersona { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string CiudadNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public string NivelInstruccion { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string DocumentoFiscal { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string CarnetExtranjeria { get; set; }
        public string DocumentoMilitarFA { get; set; }
        public string TipoBrevete { get; set; }
        public string Brevete { get; set; }
        public string Pasaporte { get; set; }
        public string NombreEmergencia { get; set; }
        public string DireccionEmergencia { get; set; }
        public string TelefonoEmergencia { get; set; }
        public string PersonaAnt { get; set; }
        public string CorreoElectronico { get; set; }
        public string EnfermedadGraveFlag { get; set; }
        public Nullable<System.DateTime> IngresoFechaRegistro { get; set; }
        public string IngresoAplicacionCodigo { get; set; }
        public string IngresoUsuario { get; set; }
        public string Celular { get; set; }
        public string ParentescoEmergencia { get; set; }
        public string CelularEmergencia { get; set; }
        public string LugarNacimiento { get; set; }
        public string SuspensionFonaviFlag { get; set; }
        public string FlagRepetido { get; set; }
        public string CodDiscamec { get; set; }
        public Nullable<System.DateTime> FecIniDiscamec { get; set; }
        public Nullable<System.DateTime> FecFinDiscamec { get; set; }
        public string Pais { get; set; }
        public string EsPaciente { get; set; }
        public string EsEmpresa { get; set; }
        public Nullable<int> Persona_Old { get; set; }
        public int personanew { get; set; }
        public string EstadoPersona { get; set; }
        public Nullable<int> IDASIGNACIONMEDICO { get; set; }
        public Nullable<int> tipoasignacion { get; set; }
        public string ObservacionesAsigMed { get; set; }
        public Nullable<int> EstadoAsigMed { get; set; }
        public Nullable<int> EstadoEpiClinico { get; set; }
        public Nullable<int> SecAsigMed { get; set; }
        public Nullable<int> SecReferidaAsigMed { get; set; }
    }
}