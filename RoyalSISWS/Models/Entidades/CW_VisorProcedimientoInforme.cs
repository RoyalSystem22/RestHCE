using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models.Entidades
{
    public class CW_VisorProcedimientoInforme
    {
        public string LinkInforme { get; set; }
        public string codigoOA { get; set; }
        public string DesEspecialidad { get; set; }
        public string Sucursal { get; set; }
        public string documento { get; set; }
        public string tipodocumento { get; set; }
        public int IdOrdenAtencion { get; set; }
        public int Linea { get; set; }
        public string Componente { get; set; }
        public string Observacion { get; set; }
        public Nullable<int> IdProcedimiento { get; set; }
        public Nullable<int> IdInforme { get; set; }
        public string Nombre { get; set; }
        public string RutaInforme { get; set; }
        public Nullable<int> Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public byte[] fileBytes { get; set; }

        //public Nullable<System.byte[]> fileBytes { get; set; }
        //public virtual Nullable fileBytes { get; set; }
        //public byte?[] byteTestIn { get; set; }
    }
}