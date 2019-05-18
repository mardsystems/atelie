using Atelie.Cadastro.Unidades;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public class ServicoDeCadastroDeComponentes : ICadastroDeComponentes
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepositorioDeComponentes repositorioDeComponentes;

        private readonly RepositorioDeUnidadesDeMedidas repositorioDeUnidadesDeMedidas;

        public ServicoDeCadastroDeComponentes(
            IUnitOfWork unitOfWork,
            IRepositorioDeComponentes repositorioDeComponentes,
            RepositorioDeUnidadesDeMedidas repositorioDeUnidadesDeMedidas
        )
        {
            this.unitOfWork = unitOfWork;

            this.repositorioDeComponentes = repositorioDeComponentes;

            this.repositorioDeUnidadesDeMedidas = repositorioDeUnidadesDeMedidas;
        }

        public async Task<IRespostaDeCadastroDeComponente> CadastraComponente(ISolicitacaoDeCadastroDeComponente solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                Componente componentePai;

                if (solicitacao.ComponentePaiId.HasValue)
                {
                    componentePai = await repositorioDeComponentes.ObtemComponente(solicitacao.ComponentePaiId.Value);
                }
                else
                {
                    componentePai = null;
                }

                var unidadeDeMedida = await repositorioDeUnidadesDeMedidas.ObtemUnidadeDeMedida(solicitacao.UnidadePadraoSigla);

                var componente = new Componente(
                    solicitacao.Id,
                    solicitacao.Nome,
                    componentePai,
                    unidadeDeMedida
                );

                //

                await repositorioDeComponentes.Add(componente);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeComponente
                {
                    Id = solicitacao.Id,
                };
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public async Task<IRespostaDeCadastroDeComponente> AtualizaComponente(int componenteId, ISolicitacaoDeCadastroDeComponente solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var componente = await repositorioDeComponentes.ObtemComponente(componenteId);

                //

                Componente componentePai;

                if (solicitacao.ComponentePaiId.HasValue)
                {
                    componentePai = await repositorioDeComponentes.ObtemComponente(solicitacao.ComponentePaiId.Value);
                }
                else
                {
                    componentePai = null;
                }

                var unidadeDeMedida = await repositorioDeUnidadesDeMedidas.ObtemUnidadeDeMedida(solicitacao.UnidadePadraoSigla);

                //

                componente.Id = solicitacao.Id;

                componente.Nome = solicitacao.Nome;

                componente.ComponentePai = componentePai;

                componente.UnidadePadrao = unidadeDeMedida;

                //

                await repositorioDeComponentes.Update(componente);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeComponente
                {
                    Id = componenteId,
                };
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public async Task ExcluiComponente(int componenteId)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var componente = await repositorioDeComponentes.ObtemComponente(componenteId);

                //

                await repositorioDeComponentes.Remove(componente);

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
