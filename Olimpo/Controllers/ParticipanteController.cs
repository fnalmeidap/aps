using Microsoft.AspNetCore.Mvc;
using Olimpo.Repository;
using Olimpo.Model;
using GoogleAuthentication;
using Olimpo.Web.Model;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace Olimpo.Controllers;
public class ParticipanteController
{
    private readonly string _googleApiEndpoint = "https://oauth2.googleapis.com/tokeninfo?id_token=";
    private static IRepositoryFactory _repositoryFactory = new RepositoryFactory();
    private static GoogleAuthenticationApi googleAuthenticationApi = new GoogleAuthenticationApi("https://oauth2.googleapis.com/tokeninfo?id_token=");
    private IRepository<Participante> cadastroParticipantes = _repositoryFactory.CreateParticipanteMemoryRepository();
    private static int generateId = 0;

    public IEnumerable<Participante> GetParticipanteList()
    {
        return cadastroParticipantes.List;
    }

    public Participante? GetParticipanteById(int Id)
    {
        var participante = cadastroParticipantes.FindById(Id);
        return participante;
    }

    public bool CreateParticipante(Participante participante)
    {
        var participanteGoogleInfo = new GoogleApiResponse();

        HttpClient client = new HttpClient();
        HttpResponseMessage response = client.GetAsync(_googleApiEndpoint + participante.TokenId).Result;
        if(response.IsSuccessStatusCode)
        {
            string responseBody = response.Content.ReadAsStringAsync().Result;
            participanteGoogleInfo = JsonConvert.DeserializeObject<GoogleApiResponse>(responseBody);
        }

        if(IsParticipanteValido(participante, participanteGoogleInfo))
        {
            participante.GoogleId = participanteGoogleInfo.sub;
            participante.Id = generateId;
            generateId += 1;

            cadastroParticipantes.Add(participante);
            return true;
        }

        return false;
    }
    public bool DeleteParticipanteById(int id)
    {
        var participante = cadastroParticipantes.FindById(id);
        if (participante == null)
        {
            return false;
        }

        cadastroParticipantes.Delete(participante);
        return true;
    }

    private bool IsParticipanteValido(Participante participante, GoogleApiResponse googleResponse)
    {
        Console.WriteLine(googleResponse.sub);
        Console.WriteLine(googleResponse.email)
        if(googleResponse == null)
        {
            return false;
        }

        if(participante.GoogleId != googleResponse.sub)
        {
            return false;
        }

        if(participante.Email != googleResponse.email)
        {
            return false;
        }

        return true;
    }
}
