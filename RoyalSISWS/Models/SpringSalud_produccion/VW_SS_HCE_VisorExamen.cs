//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoyalSISWS.Models.SpringSalud_produccion
{
    using System;
    using System.Collections.Generic;
    
    public partial class VW_SS_HCE_VisorExamen
    {
        public string TAB { get; set; }
        public string Nombre { get; set; }
        public int IdOrdenAtencion { get; set; }
        public int Linea { get; set; }
        public Nullable<int> TipoOrdenAtencion { get; set; }
        public int IdConsultaExterna { get; set; }
        public int lineaconsulta { get; set; }
        public string CodigoOA { get; set; }
        public Nullable<System.DateTime> FechaPreparacion { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFinal { get; set; }
        public Nullable<int> TipoAtencion { get; set; }
        public Nullable<int> TipoPaciente { get; set; }
        public Nullable<int> IdServicio { get; set; }
        public Nullable<int> IdEmpresaAseguradora { get; set; }
        public Nullable<int> EstadoDocumento { get; set; }
        public Nullable<int> EstadoDocumentoAnterior { get; set; }
        public Nullable<int> Estado { get; set; }
        public string IdServicio_Nombre { get; set; }
        public string IdGrupoAtencion_Nombre { get; set; }
        public Nullable<int> IdGrupoAtencion { get; set; }
        public string IdEspecialidad_Nombre { get; set; }
        public Nullable<int> Especialidad { get; set; }
        public string Componente_Nombre { get; set; }
        public Nullable<int> EstDet { get; set; }
        public Nullable<int> IndicadorEPS { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> IdPaciente { get; set; }
        public string documento { get; set; }
        public string tipodocumento { get; set; }
        public string Sucursal { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<int> GrupoInterfase { get; set; }
        public Nullable<int> SituacionInterfase { get; set; }
        public Nullable<int> IdProcedimiento { get; set; }
        public Nullable<int> EstadoDocPro { get; set; }
    }
}
