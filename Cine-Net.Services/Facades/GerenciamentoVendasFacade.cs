using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Interfaces;
using System.Collections.ObjectModel;

namespace Cine_Net.Services.Facades
{
    public class GerenciamentoVendasFacade
    {
        private readonly IUnitOfWork _unitOfWork;

        GerenciamentoVendasFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void venderIngresso()
        {

        }

        public void cancelarIngresso()
        {

        }

        public void imprimirTicket()
        {

        }

    }
}
