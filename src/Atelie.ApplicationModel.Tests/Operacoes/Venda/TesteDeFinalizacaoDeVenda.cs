using System.Transactions;
using Xunit;

namespace Atelie.Operacoes.Venda
{
    public class Ao_FinalizarVenda
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepositorioDePedidoDeVendas repositorioDePedidoDeVendas;

        private readonly ServicoDeVendaDeModelos sut;

        public Ao_FinalizarVenda()
        {
            unitOfWork = new UnitOfWorkStub();

            repositorioDePedidoDeVendas = new RepositorioDePedidoDeVendasStub();

            sut = new ServicoDeVendaDeModelos(
                unitOfWork,
                repositorioDePedidoDeVendas
            );

            sut.FinalizaVenda(1);
        }

        //public void Ao_Finalizar_PedidoDeVenda_Deve_Gerar_OrdemDeProducao()
        //{

        //}

        public class Para_Sucesso : Ao_FinalizarVenda
        {
            [Fact]
            public void Deve_Gerar_OrdemDeProducao()
            {

            }

            [Fact]
            public void Deve_DarBaixaNoEstoque()
            {

            }

            [Fact]
            public void Estoque_Deve_Baixar()
            {

            }

            [Fact]
            public void Os_Modelos_Devem_Ser_Reservados_No_Estoque()
            {
                // TODO: Busca no estoque os modelos comprados.

                // TODO: Busca o estoque dos modelos comprados.

                // TODO: 

                //var estoque = null;

                //Assert.Equal(estoque.)
            }
        }
    }
}
