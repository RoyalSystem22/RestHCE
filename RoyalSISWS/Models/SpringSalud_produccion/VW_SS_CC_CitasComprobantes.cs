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
    
    public partial class VW_SS_CC_CitasComprobantes
    {
        public long IdTransaccion { get; set; }
        public Nullable<int> IdCita { get; set; }
        public int IdComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public string TipoComprobante { get; set; }
        public string SerieComprobante { get; set; }
        public string CodigoOA { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<int> EstadoEnvioElectronico { get; set; }
        public string CodigoHashElectronico { get; set; }
    }
}
