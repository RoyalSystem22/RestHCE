using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models.Entidades
{
    public class CW_Paciente
    {
         public Nullable<int> IdPersona { get; set; }
       
        public string Clave { get; set; }
        public string ClaveAutoGenerado { get; set; }

        public string Sexo { get; set; }
        public string TipoParentesco { get; set; }
        public Nullable<int> IdTitular { get; set; }
        public string TipoDocumento { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Nombres { get; set; }
        public string NombreCompleto { get; set; }
        public Nullable<DateTime> FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public Nullable<int> Estado { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
     public string Accion { get; set; }
     public string Resultado { get; set; }
    }
}