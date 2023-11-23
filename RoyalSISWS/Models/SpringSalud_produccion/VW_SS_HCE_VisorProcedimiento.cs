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
    
    public partial class VW_SS_HCE_VisorProcedimiento
    {
        public string TAB { get; set; }
        public Nullable<int> IdOrdenAtencion { get; set; }
        public Nullable<int> LineaOrdenAtencion { get; set; }
        public int IdProcedimiento { get; set; }
        public int IdInforme { get; set; }
        public int Secuencial { get; set; }
        public Nullable<int> IdConcepto { get; set; }
        public Nullable<int> IdPlantilla { get; set; }
        public int SecuencialPlantilla { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorNumerico { get; set; }
        public string ValorCadena { get; set; }
        public Nullable<System.DateTime> ValorFecha { get; set; }
        public Nullable<int> Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string Codigo { get; set; }
        public string TipoDato { get; set; }
        public Nullable<int> IdPaciente { get; set; }
        public string documento { get; set; }
        public string tipodocumento { get; set; }
        public string Sucursal { get; set; }
    }
}
