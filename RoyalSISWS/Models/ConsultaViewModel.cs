using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models
{
    public class ConsultaViewModel
    {
        public string UnidadReplicacion { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<System.DateTime> FechaIni { get; set; }
        public Nullable<int> TipoAdmision { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<int> Persona { get; set; }
        public Nullable<int> IdSede { get; set; }
        public string IdClasificadorMovimiento { get; set; }
        public string NroPeticion { get; set; }
        public string HistoriaClinica { get; set; }
        public string UsuarioCreacion { get; set; }
        public string OrdenAtencion { get; set; }

    }
}