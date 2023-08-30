using MassTransit;
using Olimpo.Controllers;
using Olimpo.Model;
using Olimpo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Olimpo.Web
{
    class Fachada
    {
        private EquipeController equipeController;
        public readonly IPublishEndpoint publishEndpoint;

        public Fachada(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
            equipeController =  new EquipeController(publishEndpoint);
        }

        public Task<IActionResult> cadastrarEquipe(Equipe equipe)
        {
           return equipeController.CreateEquipe(equipe);
        }

        public Equipe buscarEquipe(int Id)
        {
            return equipeController.GetEquipeById(Id);
        }

        public IEnumerable<Equipe> buscarTodasEquipes()
        {
            return equipeController.GetEquipeList();
        }

        public bool cadastrarParticipanteEmEquipe(ParticipanteEquipeRequest request)
        {
            return equipeController.AddParticipanteToEquipe(request);
        }

        public bool removerEquipe(int Id)
        {
            return equipeController.DeleteEquipeById(Id);
        }
    }
}