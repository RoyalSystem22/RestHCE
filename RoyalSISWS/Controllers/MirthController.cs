using System;
using RoyalSISWS.Models;
using RoyalSISWS.Models.WEB_ERPSALUD;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoyalSISWS.Controllers
{
    public class MirthController : Controller
    {
        //
        // GET: /Mirth/

        public ActionResult Index()
        {
            return View();
        }

        #region Mirth_Procesos
        public JsonResult Mirth_DiagnosticoIngresoMantenimiento(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.Mirth_DiagnosticoIngresoMantenimiento(valor, msg);
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Mirth_ProcedimientoIngresoMantenimiento(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.Mirth_ProcedimientoIngresoMantenimiento(valor, msg);
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Mirth_OftalmologicoIngresoMantenimiento(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.Mirth_OftalmologicoIngresoMantenimiento(valor, msg);
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Mirth_Maestros

        #endregion

    }
}
