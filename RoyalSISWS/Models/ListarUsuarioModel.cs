using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoyalSISWS.Models
{
    public class ListarUsuarioModel
    {
        public Nullable<int> Id { get; set; }
        public string UserNameWeb { get; set; }
        public string PasswordWeb { get; set; }
        //public string userHash { get; set; }
        public string TipoUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<int> IdPersona { get; set; }

    }
}