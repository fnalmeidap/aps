using Microsoft.AspNetCore.Mvc;
using ServicoParticipante.Repository;
using ServicoParticipante.Model;
using Olimpo.Web.Model;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace ServicoParticipante.Controllers;
public class ParticipanteController
{
    private readonly string _googleApiEndpoint = "https://oauth2.googleapis.com/tokeninfo?id_token=";
    private static IRepositoryFactory _repositoryFactory = new RepositoryFactory();
    private IRepository<Participante> cadastroParticipantes = _repositoryFactory.CreateParticipanteMemoryRepository();
    private static int generateId = 0;

    public Participante? Login(string tokenId)
    {
        var googleResponse = RequestGoogleInformation(tokenId);
        if(googleResponse == null)
        {
            return null;
        }

        var participante = cadastroParticipantes.FindByPredicate(
            p => p.GoogleId == googleResponse.sub);

        if(IsParticipanteValido(participante, googleResponse))
        {
            return participante;
        }

        return null;
    }

    public IEnumerable<Participante> GetParticipanteList()
    {
        return cadastroParticipantes.List;
    }
    
    private GoogleApiResponse? RequestGoogleInformation(string tokenId)
    {
        var participanteGoogleInfo = new GoogleApiResponse();

        HttpClient client = new HttpClient();
        HttpResponseMessage response = client.GetAsync(_googleApiEndpoint + tokenId).Result;
        if(response.IsSuccessStatusCode)
        {
            string responseBody = response.Content.ReadAsStringAsync().Result;
            participanteGoogleInfo = JsonConvert.DeserializeObject<GoogleApiResponse>(responseBody);
        }

        return participanteGoogleInfo;
    }

    private bool IsParticipanteValido(Participante participante, GoogleApiResponse googleResponse)
    {
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


    public Participante? GetParticipanteById(int Id)
    {
        var participante = cadastroParticipantes.FindById(Id);
        return participante;
    }

    public bool CreateParticipante(Participante participante)
    {
        var googleResponse = RequestGoogleInformation(participante.TokenId);
        if (googleResponse == null)
        {
            return false;
        }

        if (IsParticipanteValido(participante, googleResponse))
        {
            participante.GoogleId = googleResponse.sub;
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
}
