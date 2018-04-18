using HollywoodTest.Shared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace HollywoodTest.UI.Services
{
    public class ErrorService
    {
        readonly string baseUri = WebConfigurationManager.AppSettings["APIurl"] + "ErrorLog";

        public async Task Log(ErrorLog errorLog)
        {
            string uri = baseUri + "/Log";
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(errorLog);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, stringContent);
                
            }
        }
    }
}