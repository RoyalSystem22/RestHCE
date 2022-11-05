using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Entidad
{
    public partial class SS_HC_WS_EpisodioAtencion
    {

        #region Variables Locales
        public string UnidadReplicacion { get; set; }
        public Nullable<int> IdEpisodioAtencion { get; set; }
        public Nullable<int> IdPaciente { get; set; }
        public Nullable<int> EpisodioClinico { get; set; }
        public Nullable<int> IdOrdenAtencion { get; set; }
        public Nullable<int> Linea { get; set; }
        public string SecuenciaHCE{ get; set; }
        public string Accion{ get; set; }
        public string Version{ get; set; }
        public Nullable<int> Estado{ get; set; }
        public string UsuarioCreacion{ get; set; }
        public Nullable<System.DateTime> FechaCreacion{ get; set; }
        public string UsuarioModificacion{ get; set; }
        public Nullable<System.DateTime> FechaModificacion{ get; set; }
        
        #endregion
    }
}