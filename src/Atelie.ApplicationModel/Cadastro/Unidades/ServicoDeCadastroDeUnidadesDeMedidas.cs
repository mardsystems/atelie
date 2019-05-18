using Atelie.Comum;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelie.Cadastro.Unidades
{
    public class ServicoDeCadastroDeUnidadesDeMedidas : ICadastroDeUnidadesDeMedidas
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly RepositorioDeUnidadesDeMedidas repositorioDeUnidades;

        public ServicoDeCadastroDeUnidadesDeMedidas(
            IUnitOfWork unitOfWork,
            RepositorioDeUnidadesDeMedidas repositorioDeUnidades
        )
        {
            this.unitOfWork = unitOfWork;

            this.repositorioDeUnidades = repositorioDeUnidades;
        }

        public async Task<IRespostaDeCadastroDeUnidade> CadastraUnidade(ISolicitacaoDeCadastroDeUnidade solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var unidade = new UnidadeDeMedida(
                    solicitacao.Sigla,
                    solicitacao.NomeNoSingular,
                    solicitacao.NomeNoPlural
                );

                //

                await repositorioDeUnidades.Add(unidade);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeUnidadeDeMedida
                {
                    Sigla = solicitacao.Sigla,
                };
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public async Task<IRespostaDeCadastroDeUnidade> AtualizaUnidade(string sigla, ISolicitacaoDeCadastroDeUnidade solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var unidade = await repositorioDeUnidades.ObtemUnidadeDeMedida(sigla);

                //

                unidade.Sigla = solicitacao.Sigla;

                unidade.NomeNoSingular = solicitacao.NomeNoSingular;

                unidade.NomeNoPlural = solicitacao.NomeNoPlural;

                //

                await repositorioDeUnidades.Update(unidade);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeUnidadeDeMedida
                {
                    Sigla = solicitacao.Sigla,
                };
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public async Task ExcluiUnidade(string sigla)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var unidade = await repositorioDeUnidades.ObtemUnidadeDeMedida(sigla);

                //

                await repositorioDeUnidades.Remove(unidade);

                //

                await unitOfWork.Commit();
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }
    }
}
