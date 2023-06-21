using Cine_Net.Infra.Interfaces;

namespace Cine_Net.Services.Facades
{
    public class GerenciamentoVendasFacade
    {
        private readonly IUnitOfWork _unitOfWork;

        private GerenciamentoVendasFacade(IUnitOfWork unitOfWork)
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