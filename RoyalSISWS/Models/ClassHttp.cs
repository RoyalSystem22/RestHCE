using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System. Threading.Tasks;

namespace RoyalSISWS.Models
{
    public class ClassHttp
    {
           static async Task listarParametro(string url )
           {
               using (var clienteHttp = new HttpClient())
               {
                   var response = await clienteHttp.GetAsync(url);
                   var request = await response.Content.ReadAsStringAsync();
               }
           }
           

    }
}