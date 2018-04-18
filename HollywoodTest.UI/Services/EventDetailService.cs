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
    public class EventDetailService
    {
        readonly string baseUri = WebConfigurationManager.AppSettings["APIurl"] + "EventDetail/";

        public List<EventDetail> GetEventDetails(long eventID)
        {
            string uri = baseUri+ "Get?eventID=" + eventID;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<List<EventDetail>>(response.Result).Result;
            }
        }

        public async Task<int> CreateEventDetail(EventDetail eventDetail)
        {
            string uri = baseUri + "/Create";
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(eventDetail);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, stringContent);
                return JsonConvert.DeserializeObjectAsync<int>(response.Content.ToString()).Result;
            }
        }

        public async Task<int> UpdateEventDetail(EventDetail eventDetail)
        {
            string uri = baseUri + "/Update";
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(eventDetail);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(uri, stringContent);
                return JsonConvert.DeserializeObjectAsync<int>(response.Content.ToString()).Result;
            }
        }

        public async Task<bool> DeleteEventDetail(long eventDetailID)
        {
            string uri = baseUri + "/Delete?eventDetailID=" + eventDetailID;
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(uri);
                return JsonConvert.DeserializeObjectAsync<bool>(response.Content.ToString()).Result;
            }
        }
    }
}