using System.Transactions;
using Xunit;

namespace Atelie.Operacoes.Producao
{
    public class Ao_FinalizarProducao
    {
        protected readonly IUnitOfWork unitOfWork;

        protected readonly IRepositorioDeOrdemDeProducao repositorioDeOrdemDeProducao;

        protected readonly ServicoDeProducaoDeModelos sut;

        public Ao_FinalizarProducao()
        {
            unitOfWork = new UnitOfWorkStub();

            repositorioDeOrdemDeProducao = new RepositorioDeOrdemDeProducaoStub();

            sut = new ServicoDeProducaoDeModelos(
                unitOfWork,
                repositorioDeOrdemDeProducao
            );

            sut.FinalizaProducao(1);
        }

        //public void Ao_Finalizar_PedidoDeVenda_Deve_Gerar_OrdemDeProducao()
        //{

        //}

        public class Para_Sucesso : Ao_FinalizarProducao
        {
            [Fact]
            public async void Status_Deve_Ser_Igual_A_Finalizada()
            {
                var ordemDeProducaoFinalizada = await repositorioDeOrdemDeProducao.ObtemOrdemDeProducao(1);

                Assert.Equal(StatusDeOrdemDeProducao.Finalizada, ordemDeProducaoFinalizada.Status);
            }

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
            public void Quantidade_Do_RegistroDeEstoque_Deve_Ser_Igual_A_Quantidade_Produzida()
            {
                // TODO: Busca no estoque os modelos comprados.

                // TODO: Busca o estoque dos modelos comprados.

                // TODO: 

                //var estoque = null;

                //Assert.Equal(estoque.)
            }
        }

        public class Ao_RegistrarEstoque : Ao_FinalizarProducao
        {
            public class Para_Sucesso : Ao_RegistrarEstoque
            {
                [Fact]
                public async void Status_Deve_Ser_Igual_A_Finalizada()
                {
                    var ordemDeProducaoFinalizada = await repositorioDeOrdemDeProducao.ObtemOrdemDeProducao(1);

                    Assert.Equal(StatusDeOrdemDeProducao.Finalizada, ordemDeProducaoFinalizada.Status);
                }

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
                public void Quantidade_Do_RegistroDeEstoque_Deve_Ser_Igual_A_Quantidade_Produzida()
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
}
