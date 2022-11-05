using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using RoyalSISWS.Models.Entidades;
using System.Xml.Linq;


namespace RoyalSISWS.Models
{
    public class DA_Funciones
    {
        const string Comillas = "\"";
        //const string strConsUsuario = "usuario";
        //const string strConsPassword = "password";
            const string strConsUsuario = "20100054184";
            const string strConsPassword = "Nr1welFhAJp0OOYZZ/2JIqxFKLkPluqtkoTvIEIzNvgrmqQp02cAstyiVGtS1N2ohBFroGQkM3oZfFQohKY/YWVJ/gKtB332rRQcm65UgrghNyxboh3GDq6VxKHjkUPl0IguyPu56daAsFSNPytZ+jxbzbq0tBsPbS3lZ+amxiY=|u9704128ua001u67l0180s46u41a6u214su021uu62l5s276l0u88u57s551uss9|h5LhaWoBEpEqE5QKnQixGadszlxbRmQLmLbYyfuDXlQ=";

        

            //public int getConsultaEntVinculada(E_278_CON_ENT_VINC p_request, ref E_278_RES_ENT_VINC p_response)
            //{
            //    string strTramaRequest = null;
            //    string strXMLRequest = null;
            //    string strXMLResponse = null;

            //    ConEntVinc278ServiceImpl ServicioRequest = new ConEntVinc278ServiceImpl();

            //    ResEntVinc278ServiceImpl ServicioResponse = new ResEntVinc278ServiceImpl();

            //    InConEntVinc278 beanRequest = new InConEntVinc278();
            //    InResEntVinc278 beanResponse = new InResEntVinc278();
            //    E_278_RES_ENT_VINC objResponse = new E_278_RES_ENT_VINC();

            //    try
            //    {
            //        beanRequest.setCaIPRESS(p_request.CaIPRESS);
            //        beanRequest.setFeTransaccion(p_request.FeTransaccion);
            //        beanRequest.setHoTransaccion(p_request.HoTransaccion);
            //        beanRequest.setIdCorrelativo(p_request.IdCorrelativo);
            //        beanRequest.setIdReceptor(p_request.IdReceptor);
            //        beanRequest.setIdRemitente(p_request.IdRemitente);
            //        beanRequest.setIdTransaccion(p_request.IdTransaccion);
            //        beanRequest.setNoIPRESS(p_request.NoIPRESS);
            //        beanRequest.setNoTransaccion(p_request.NoTransaccion);
            //        beanRequest.setNuControl(p_request.NuControl);
            //        beanRequest.setNuControlST(p_request.NuControlST);
            //        beanRequest.setNuRucIPRESS(p_request.NuRucIPRESS);
            //        beanRequest.setTiDoIPRESS(p_request.TiDoIPRESS);
            //        beanRequest.setTiFinalidad(p_request.TiFinalidad);

            //        strTramaRequest = ServicioRequest.beanToX12N(beanRequest);
                    
                     
               
            //        fncObtenerXML("getConsultaEntVinculadaRequest", "278_CON_ENT_VINC", p_request.IdReceptor, strTramaRequest, ref strXMLRequest);
                  
            //        fncInvocarServicio(strXMLRequest, ref strXMLResponse);

            //        XmlDocument xmltest = new XmlDocument();
            //        xmltest.LoadXml(strXMLResponse);
            //        XmlNodeList elemlist = xmltest.GetElementsByTagName("coError");
            //        string result = elemlist[0].InnerXml;

            //        XmlNodeList elemlist1 = xmltest.GetElementsByTagName("txRespuesta");
            //        string result1 = elemlist1[0].InnerXml;

            //        //if (xmlResponse.coError == "0000")
            //        if (result == "0000")
            //        {
            //            //beanResponse = ServicioResponse.x12NToBean(xmlResponse.txRespuesta);
            //            beanResponse = ServicioResponse.x12NToBean(result1);
            //            objResponse.FeTransaccion = beanResponse.getFeTransaccion();
            //            objResponse.HoTransaccion = beanResponse.getHoTransaccion();
            //            objResponse.IdCorrelativo = beanResponse.getIdCorrelativo();
            //            objResponse.IdReceptor = beanResponse.getIdReceptor();
            //            objResponse.IdRemitente = beanResponse.getIdRemitente();
            //            objResponse.IdTransaccion = beanResponse.getIdTransaccion();
            //            objResponse.MsgRespuesta = beanResponse.getMsgRespuesta();
            //            objResponse.NoTransaccion = beanResponse.getNoTransaccion();
            //            objResponse.NuControl = beanResponse.getNuControl();
            //            objResponse.NuControlST = beanResponse.getNuControlST();
            //            objResponse.Respuesta = beanResponse.getRespuesta();
            //            objResponse.TiFinalidad = beanResponse.getTiFinalidad();
            //            p_response = objResponse;
            //        }

            //    }
            //    catch (WebException e)
            //    {
            //        if (e.Status == WebExceptionStatus.ProtocolError)
            //        {
            //            string error = new System.IO.StreamReader(e.Response.GetResponseStream()).ReadToEnd();
            //        }
            //    }
            //    finally
            //    {

            //    }
            //    return 0;
            //}


            //private void fncObtenerXML(string va, string de, string IdReceptor, string strTramaRequest, ref string strXMLRequest)
            //{


            //     }

    }
}