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

        public async Task<bool> CreateTournament(Tournament tournament)
        {
            string uri = baseUri + "/Create";
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(tournament);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, stringContent);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> UpdateTournament(Tournament tournament)
        {
            string uri = baseUri + "/Update";
            using (HttpClient httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(tournament);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(uri, stringContent);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteTournament(long tournamentID)
        {
            string uri = baseUri + "/Delete?tournamentID="+ tournamentID;
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(uri);
                return response.IsSuccessStatusCode;
            }
        }

    }
}