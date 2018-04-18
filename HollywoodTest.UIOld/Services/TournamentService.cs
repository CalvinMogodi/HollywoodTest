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

namespace HollywoodTest.UI.Models
{
    public class TournamentService
    {
        readonly string baseUri = WebConfigurationManager.AppSettings["APIurl"] + "Tournament";

        public List<Tournament> GetTournaments()
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<List<Tournament>>(response.Result).Result;
            }
        }

        public async Task<int> CreateTournament(Tournament tournament)
        {
            string uri = baseUri + "/Create";
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(tournament);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, stringContent);
                return JsonConvert.DeserializeObjectAsync<int>(response.Content.ToString()).Result;
            }
        }

    }
}