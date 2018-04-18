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
    public class EventService
    {
        readonly string baseUri = WebConfigurationManager.AppSettings["APIurl"] + "Event/";

        public List<Shared.Models.Event> GetEvents(long tournamentID)
        {
            string uri = baseUri + "Get?tournamentID=" + tournamentID;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<List<Shared.Models.Event>>(response.Result).Result;
            }
        }
    }
}