using System;
using Newtonsoft.Json;
using ServicoEquipe.Model;
using System.Net.Http;

namespace ServicoParticipante.Web
{
    class ParticipanteService
    {
        private readonly string _endpoint;
        private readonly string _route = "partcipante";
        private HttpClient _client = new HttpClient();

        public ParticipanteService(string endpoint)
        {
            _endpoint = endpoint;
        }

        public Participante? FindParticipanteById(int equipeId)
        {
            string query = string.Format("/{0}/{1}", _route, equipeId);
            var response = _client.GetAsync("http://localhost:5211/api/participante/" + equipeId).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                Participante particpante = JsonConvert.DeserializeObject<Participante>(responseBody);
                
                return particpante;
            }
            
            return null;
        }
    }
}