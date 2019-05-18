using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelie.Operacoes.Producao
{
    public class ServicoDeProducaoDeModelos : IProducaoDeModelos
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepositorioDeOrdemDeProducao repositorioDeOrdemDeProducao;

        public ServicoDeProducaoDeModelos(
            IUnitOfWork unitOfWork,
            IRepositorioDeOrdemDeProducao repositorioDeOrdemDeProducao
        )
        {
            this.unitOfWork = unitOfWork;

            this.repositorioDeOrdemDeProducao = repositorioDeOrdemDeProducao;
        }

        public Task IniciaProducao()
        {
            throw new NotImplementedException();
        }

        public async Task FinalizaProducao(int id)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var ordemDeProducao = await repositorioDeOrdemDeProducao.ObtemOrdemDeProducao(id);

                //

                ordemDeProducao.Finaliza();

                //

                await repositorioDeOrdemDeProducao.Update(ordemDeProducao);

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
