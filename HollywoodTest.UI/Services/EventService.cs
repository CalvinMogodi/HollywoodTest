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
    public class EventService
    {
        readonly string baseUri = WebConfigurationManager.AppSettings["APIurl"] + "Event/";

        public List<Event> GetEvents(long tournamentID)
        {
            string uri = baseUri + "Get?tournamentID=" + tournamentID;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<List<Event>>(response.Result).Result;
            }
        }

        public async Task<int> CreateEvent(Event _event)
        {
            string uri = baseUri + "/Create";
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(_event);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, stringContent);
                return JsonConvert.DeserializeObjectAsync<int>(response.Content.ToString()).Result;
            }
        }

        public async Task<int> UpdateEvent(Event _event)
        {
            string uri = baseUri + "/Update";
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(_event);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(uri, stringContent);
                return JsonConvert.DeserializeObjectAsync<int>(response.Content.ToString()).Result;
            }
        }

        public async Task<bool> DeleteEvent(long eventID)
        {
            string uri = baseUri + "/Delete?tournamentID=" + eventID;
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(uri);
                return JsonConvert.DeserializeObjectAsync<bool>(response.Content.ToString()).Result;
            }
        }
    }
}