using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelie.Operacoes.Venda
{
    public class ServicoDeVendaDeModelos : IVendaDeModelos
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepositorioDePedidoDeVendas repositorioDePedidoDeVendas;

        public ServicoDeVendaDeModelos(
            IUnitOfWork unitOfWork,
            IRepositorioDePedidoDeVendas repositorioDePedidoDeVendas
        )
        {
            this.unitOfWork = unitOfWork;

            this.repositorioDePedidoDeVendas = repositorioDePedidoDeVendas;
        }

        public Task IniciaVenda()
        {
            throw new NotImplementedException();
        }

        public async Task FinalizaVenda(int id)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var pedidoDeVenda = await repositorioDePedidoDeVendas.ObtemPedidoDeVenda(id);

                //

                pedidoDeVenda.Finaliza();

                //

                await repositorioDePedidoDeVendas.Update(pedidoDeVenda);

                //

                await unitOfWork.Commit();
            }
            catch (Exception)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }
    }
}
