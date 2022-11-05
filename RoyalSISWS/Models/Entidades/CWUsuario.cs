using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models.Entidades
{
    public class CWUsuario
    {
        public string Accion { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        //public string userHash { get; set; }
        public string TipoDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<int> IdPersona { get; set; }
    }
}