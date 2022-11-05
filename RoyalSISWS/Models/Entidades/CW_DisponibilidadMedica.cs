using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models.Entidades
{
    public class CW_DisponibilidadMedica
    {
        public Nullable<System.DateTime> Fecha { get; set; }
        public int IdMedico { get; set; }
        public Nullable<int> IdTurno { get; set; }
        public Nullable<int> IdCita { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFinal { get; set; }
        public int IdHorario { get; set; }
        public Nullable<int> TiempoPromedioAtencion { get; set; }
        public string CMP { get; set; }
        public string IdMedico_Nombre { get; set; }
        public Nullable<int> IdEspecialidad { get; set; }
        public string IdEspecialidad_Nombre { get; set; }
        public Nullable<int> IdConsultorio { get; set; }
        public string IdConsultorio_Nombre { get; set; }
        public string UnidadReplicacion { get; set; }
        public Nullable<int> IdOrdenAtencion { get; set; }

        public Nullable<int> Linea { get; set; }

    }
}