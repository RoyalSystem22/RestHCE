using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Entidad
{
    public partial class Formulario
    {

        public string Titulo { get; set; }
        public string Tabla { get; set; }
        public string Accion { get; set; }
        public string Version { get; set; }
        public string TipoFormulario { get; set; }
        public string Ruta { get; set; }
        public string EpisodioClinico { get; set; }
        public string EpisodioAtencion { get; set; }

    }
}