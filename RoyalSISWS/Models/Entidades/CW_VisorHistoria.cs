using System;
using System.Collections.Generic;
using RoyalSISWS.Models.SpringSalud_produccion;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models.Entidades
{
    public class CW_VisorHistoria
    {
        public string CitaTipo { get; set; }
        public string CitaFecha { get; set; }
        public string CitaHora { get; set; }
        public string Origen { get; set; }
        public string Aseguradora { get; set; }
        
        public string NombreEspecialidad { get; set; }
        public string TipoPacienteNombre { get; set; }
        public string CodigoOA { get; set; }
        public string Cama { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public string TipoOrdenAtencionNombre { get; set; }
        public string CodigoHC { get; set; }
        public string CodigoHCAnterior { get; set; }
        public string PacienteNombre { get; set; }
        public string MedicoNombre { get; set; }
        public int IdOrdenAtencion { get; set; }
        public int LineaOrdenAtencion { get; set; }
        public int IdHospitalizacion { get; set; }
        public int LineaHospitalizacion { get; set; }
        public Nullable<int> IdConsultaExterna { get; set; }
        public Nullable<int> IdProcedimiento { get; set; }
        public Nullable<int> Modalidad { get; set; }
        public Nullable<int> IndicadorSeguro { get; set; }
        public Nullable<int> IdCita { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public int IdPaciente { get; set; }
        public Nullable<int> TipoPaciente { get; set; }
        public Nullable<int> TipoAtencion { get; set; }
        public Nullable<int> IdEspecialidad { get; set; }
        public Nullable<int> IdEmpresaAseguradora { get; set; }
        public Nullable<int> TipoOrdenAtencion { get; set; }
        public string Componente { get; set; }
        public string ComponenteNombre { get; set; }
        public string Compania { get; set; }
        public string Sucursal { get; set; }
        public Nullable<int> IdMedico { get; set; }
        public int IndicadorCirugia { get; set; }
        public int IndicadorExamenPrincipal { get; set; }
        public string UnidadReplicacionHCE { get; set; }
        public Nullable<int> EstadoEpiAtencion { get; set; }
        public Nullable<int> EpisodioClinicoHCE { get; set; }
        public Nullable<int> IDEPISODIOAtencionHCE { get; set; }
        public Nullable<int> IdPacienteHCE { get; set; }
        public Nullable<int> SecuenciaHCE { get; set; }
        public string PersonaAnt { get; set; }
        public string sexo { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public string NivelInstruccion { get; set; }
        public string Direccion { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string LugarNacimiento { get; set; }
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string EsPaciente { get; set; }
        public string EsEmpresa { get; set; }
        public string Pais { get; set; }
        public string EstadoPersona { get; set; }
        public string UnidadReplicacionEC { get; set; }
        public string TipoAtencionDescX { get; set; }

        public virtual List<VW_SS_HCE_VisorExamen> list_VW_SS_HCE_VisorExamen { get; set; }
        public virtual List<VW_SS_HCE_VisorAnamnesis> list_VW_SS_HCE_VisorAnamnesis { get; set; }
        public virtual List<VW_SS_HCE_VisorDiagnostico> list_VW_SS_HCE_VisorDiagnostico { get; set; }
        public virtual List<VW_SS_HCE_VisorReceta> list_VW_SS_HCE_VisorReceta { get; set; }
        public virtual List<VW_SS_HCE_VisorDescansoMedico> list_VW_SS_HCE_VisorDescansoMedico { get; set; }
        public virtual List<VW_SS_HCE_VisorProcedimiento> list_VW_SS_HCE_VisorProcedimiento { get; set; }
        

    }
}