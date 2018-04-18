using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace HollywoodTest.UI.Models
{
    public class EventDetailService
    {
        readonly string baseUri = WebConfigurationManager.AppSettings["APIurl"] + "EventDetail/";

        public List<Shared.Models.EventDetail> GetEventDetails(long eventID)
        {
            string uri = baseUri+ "Get?eventID=" + eventID;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<List<Shared.Models.EventDetail>>(response.Result).Result;
            }
        }
    }
}