using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models.Entidades
{
    public class CW_Bandeja
    {
        public string tipoListado { get; set; }
        public string Sucursal { get; set; }
        public string CodigoOA { get; set; }
        public string PacienteNombre { get; set; }
        public Nullable<int> IdMedico { get; set; }
        public Nullable<DateTime> FechaInicio { get; set; }
        public Nullable<DateTime> FechaFinal { get; set; }          
    }
}