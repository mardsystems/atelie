using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelie.Decisoes.Comerciais
{
    public class ServicoDePlanejamentoComercial : IPlanejamentoComercial
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepositorioDePlanosComerciais repositorioDePlanosComerciais;

        //private readonly IRepositorioDeModelos repositorioDeModelos;

        public ServicoDePlanejamentoComercial(
            IUnitOfWork unitOfWork,
            IRepositorioDePlanosComerciais repositorioDePlanosComerciais
        //IRepositorioDeModelos repositorioDeModelos,
        )
        {
            this.unitOfWork = unitOfWork;

            this.repositorioDePlanosComerciais = repositorioDePlanosComerciais;

            //this.repositorioDeModelos = repositorioDeModelos;
        }

        public async Task<IRespostaDeCriacaoDePlanoComercial> CriaPlanoComercial(ISolicitacaoDeCriacaoDePlanoComercial solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                //var fabricante = await repositorioDeModelos.ObtemFabricante(solicitacao.FabricanteId);

                var planoComercial = new PlanoComercial(
                    solicitacao.Id,
                    solicitacao.Nome,
                    solicitacao.ReceitaBrutaMensal,
                    solicitacao.Margem
                //solicitacao.Descricao,
                //solicitacao.CustoPadrao,
                //fabricante,
                //componente
                );

                //

                await repositorioDePlanosComerciais.Add(planoComercial);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCriacaoDePlanoComercial
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

        public async Task<IRespostaDeCriacaoDePlanoComercial> AtualizaPlanoComercial(string planoComercialId, ISolicitacaoDeCriacaoDePlanoComercial solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var planoComercial = await repositorioDePlanosComerciais.ObtemPlanoComercial(planoComercialId);

                //

                //var fabricante = await repositorioDeModelos.ObtemFabricante(solicitacao.FabricanteId);

                //

                planoComercial.Id = solicitacao.Id;

                planoComercial.Nome = solicitacao.Nome;

                //planoComercial.Fabricante = fabricante;

                //

                await repositorioDePlanosComerciais.Update(planoComercial);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCriacaoDePlanoComercial
                {
                    Id = planoComercialId,
                };
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public async Task ExcluiPlanoComercial(string planoComercialId)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var planoComercial = await repositorioDePlanosComerciais.ObtemPlanoComercial(planoComercialId);

                //

                await repositorioDePlanosComerciais.Remove(planoComercial);

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
