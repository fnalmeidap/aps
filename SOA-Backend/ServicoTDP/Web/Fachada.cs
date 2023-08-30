using Olimpo.Controllers;
using Olimpo.Model;
using Olimpo.Repository;
using System.Runtime.Intrinsics.Arm;

namespace Olimpo.Web
{
    class Fachada
    {
        private TdpController tdpController = new TdpController();


        public void cadastrarTDP(TDP tdp)
        {
            tdpController.CreateTdp(tdp);
        }

        public void atualizarTDP(TDP tdp)
        {
            tdpController.atualizarTDP(tdp);
        }

        public TDP? buscarTDP(int Id)
        {
            return tdpController.GetTDPById(Id);
        }

        public IEnumerable<TDP> listarTDPs()
        {
            return tdpController.GetTDPList();
        }

        public TDP? listarTDPByEquipe(int equipeId)
        {
            return tdpController.GetTDPByEquipe(equipeId);
        }

        public IEnumerable<TDP> listarTDPsEmEvento(int eventoId)
        {
            return tdpController.buscarTDPsEmEvento(eventoId);
        }

        public TDP? listarTDPByEquipeCategoria(int equipeId, CategoriasType categorias)
        {
            return tdpController.GetTDPByEquipeCategoria(equipeId, categorias);
        }

        public bool deleteTDPByEquipeCategoria(int equipeId, CategoriasType categorias)
        {
           return tdpController.DeleteTdpById(equipeId, categorias);
        }

    }
}