using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Services;
using RoyalSISWS.Models;

namespace RoyalSISWS
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string SoaUsuarioPaciente(int Id, ListarUsuarioModel consulta)
        //{
        //    try
        //    {
        //        if (Id == 1)
        //        {
        //            Metodos m = new Metodos();
        //            return JsonConvert.SerializeObject(m.CW_ListarAcceso(consulta), Newtonsoft.Json.Formatting.Indented);
        //        }
        //        else
        //        {
        //            return JsonConvert.SerializeObject("Error : " + " | " + consulta.UserNameWeb + " | " + consulta.PasswordWeb, Newtonsoft.Json.Formatting.Indented); ;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        //BaseDatos.WriteLog(System.DateTime.Now + " | " + "Error Asignacion: " + " | " + consulta.UsuarioCreacion + " | " + exception.StackTrace);
        //        return JsonConvert.SerializeObject("Error : " + " | " + consulta.PasswordWeb + " | " + exception.StackTrace, Newtonsoft.Json.Formatting.Indented);
        //    }
        //}

      

    }
}
