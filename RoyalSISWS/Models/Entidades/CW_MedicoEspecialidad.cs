using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models.Entidades
{
    public class CW_MedicoEspecialidad
    {
        public int IdMedico { get; set; }
        public string NombreCompleto { get; set; }
        public Nullable<int> idEspecialidad { get; set; }
        public string Nombre { get; set; }
        public string CMP { get; set; }
        public string NumeroRegistroEspecialidad { get; set; }
        public string Foto { get; set; }
        public string RutaCurriculum { get; set; }
        public virtual List<CW_DisponibilidadMedica> list_DisponibilidadMedica { get; set; }
    }

}