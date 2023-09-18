using RoyalSISWS.Models;
using RoyalSISWS.Models.WEB_ERPSALUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoyalSISWS.Controllers
{
    public class FormatoController : Controller
    {
        //
        // GET: /Formato/
        #region CCEPF330_FORMULARIO
        public JsonResult ListarInformeConsultaExterna(SS_HC_InformeConsultaExterna_FE consulta)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            try
            {
                List<SS_HC_InformeConsultaExterna_FE> objLista = new List<SS_HC_InformeConsultaExterna_FE>();
                objLista = m.InformeConsultaExternaListar(consulta);
                obje.ok = true;
                obje.valor = objLista.Count;
                obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(objLista);
            }
            catch (Exception ex)
            { 
                obje.ok = false;
                obje.valor = 0;
                obje.msg = Newtonsoft.Json.JsonConvert.SerializeObject(ex);               
            }
            return Json(obje, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MantenimientoInformeConsultaExterna(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.HC_InformeConsultaExternaMantenimiento(valor, msg);
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
