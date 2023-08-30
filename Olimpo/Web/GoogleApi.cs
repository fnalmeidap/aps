using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Olimpo.Web.Model;

namespace GoogleAuthentication
{
    public class GoogleAuthenticationApi
    {
        private readonly string _endpoint
        ;
        public GoogleAuthenticationApi(string endpoint)
        {
            _endpoint = endpoint;
        }

        public async void GetGoogleId(GoogleApiResponse participanteGoogleInfo, string tokenId)
        {

        }
    }
}