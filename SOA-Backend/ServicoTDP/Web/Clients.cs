using System;
using Newtonsoft.Json;
using ServicoTDP.Model;
using System.Net.Http;

namespace ServicoTDP.Web
{
    class EquipeService
    {
        private readonly string _endpoint;
        private readonly string _route = "equipe";
        private HttpClient _client = new HttpClient();

        public EquipeService(string endpoint)
        {
            _endpoint = endpoint;
        }

        public Equipe? FindEquipeById(int equipeId)
        {
            string query = string.Format("/{0}/{1}", _route, equipeId);
            var response = _client.GetAsync("http://localhost:5211/api/equipe/"+equipeId).Result;
            if(response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                Equipe equipe = JsonConvert.DeserializeObject<Equipe>(responseBody);
                
                return equipe;
            }
            
            return null;
        }
    }

    class EventoService
    {
        private readonly string _endpoint;
        private readonly string _route = "evento";
        private HttpClient _client = new HttpClient();

        public EventoService(string endpoint)
        {
            _endpoint = endpoint;
        }

        public Equipe? FindEventoById(int eventoId)
        {
            string query = string.Format("/{0}/{1}", _route, eventoId);
            var response = _client.GetAsync("http://localhost:5211/api/evento/"+eventoId).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                Equipe equipe = JsonConvert.DeserializeObject<Equipe>(responseBody);

                return equipe;
            }

            return null;
        }
    }
}