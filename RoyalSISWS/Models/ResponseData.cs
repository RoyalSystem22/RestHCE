using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models
{
    public class ResponseData
    {
        public string Persona { get; set; }
        public string CodAgente { get; set; }
        public string Nombre { get; set; }
        public string IdAgente { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string CorreoPersonal { get; set; }
        public string Estado { get; set; }
        public string TipoPago { get; set; }
        public string CarneAsistenciaSocial { get; set; }
        public string TipoPlanilla { get; set; }
        public string CMP { get; set; }
        public string IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public string Token { get; set; }
    }
}