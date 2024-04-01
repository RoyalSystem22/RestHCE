using System;
using RoyalSISWS.Models;
using RoyalSISWS.Models.WEB_ERPSALUD;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoyalSISWS.Models.SpringSalud_produccion;
using System.Text.RegularExpressions;

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
      
        public JsonResult SaludRecetaIndicacionesGENIngresoMantenimiento(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.SaludRecetaIndicacionesGENIngresoMantenimiento(valor, msg);
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
        }
        
        public JsonResult SaludRecetaIngresoMantenimiento(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.SaludRecetaIngresoMantenimiento(valor, msg);
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SaludInformeRutaIngresoMantenimiento(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.SaludInformeRutaIngresoMantenimiento(valor, msg);
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SaludInformePROCIngresoMantenimiento(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.SaludInformePROCIngresoMantenimiento(valor, msg);
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

        public ActionResult Mirth_SaludAnamnesisIngresoMantenimiento(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.Mirth_SaludAnamnesisIngresoMantenimiento(valor, msg);
                //return Json(obje, JsonRequestBehavior.AllowGet);
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obje);
                jsonString = jsonString.Replace("\n", "");
                jsonString = Regex.Replace(jsonString, @"[^\u0000-\u007F]+", string.Empty);
                return Content(jsonString, "application/json");
            }
            else
            {
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Mirth_SaludDescansoMedicoMantenimiento(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            if (valor == 1 || valor == 2)
            {
                obje = m.Mirth_SaludDescansoMedicoMantenimiento(valor, msg);
                //return Json(obje, JsonRequestBehavior.AllowGet);
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obje);
                jsonString = jsonString.Replace("\n", "");
                jsonString = Regex.Replace(jsonString, @"[^\u0000-\u007F]+", string.Empty);
                return Content(jsonString, "application/json");
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
