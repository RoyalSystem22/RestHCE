using RoyalSISWS.Models;
using RoyalSISWS.Models.SpringSalud_produccion;
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
                SS_IT_SaludOFTALMOLOGICOIngreso objSC = (SS_IT_SaludOFTALMOLOGICOIngreso)Newtonsoft.Json.JsonConvert.DeserializeObject(msg, typeof(SS_IT_SaludOFTALMOLOGICOIngreso));
                m.Mirth_AnamnesisInFormeMedicoMantenimiento(1, objSC);
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SALUD_GenerarLlamado(Nullable<int> valor, string msg)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();

            switch (valor)
            {
                case 1:
                         obje = m.SALUD_GenerarLlamado(valor, msg);
                         break;  
                case 2:
                        obje = m.SALUD_GenerarLlamado(valor, msg);               
                        break;
                case 3:
                        obje = m.SALUD_GenerarLlamado(valor, msg);
                        break;
              
            }
            return Json(obje, JsonRequestBehavior.AllowGet);
        
        }

        public JsonResult Lista_InterConsultaSalida(SP_SS_HC_InterConsultaSalida_Lista_Result consulta)
        {
            Metodos m = new Metodos();
            ViewResponse obje = new ViewResponse();
            try
            {
                List<SP_SS_HC_InterConsultaSalida_Lista_Result> objLista = new List<SP_SS_HC_InterConsultaSalida_Lista_Result>();
                objLista = m.Lista_InterConsultaSalida(consulta);
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

        #endregion
    }
}
