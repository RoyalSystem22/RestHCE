using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models.Entidades
{
    public class CW_Disponibilidad
    {  
        public Nullable<DateTime> FechaInicio { get; set; }
        public Nullable<DateTime> FechaFinal { get; set; }
        public Nullable<int> IdEspecialidad { get; set; }
        public string Indicador { get; set; }        
        public Nullable<int> IdMedico { get; set; }
        public string UnidadReplicacion { get; set; }
        public Nullable<int> Disponible { get; set; }
        public Nullable<int> Accion { get; set; }

    }
}