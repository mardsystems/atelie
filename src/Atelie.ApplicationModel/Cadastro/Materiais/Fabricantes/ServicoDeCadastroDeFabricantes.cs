using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class ServicoDeCadastroDeFabricantes : ICadastroDeFabricantes
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepositorioDeFabricantes repositorioDeFabricantes;

        public ServicoDeCadastroDeFabricantes(
            IUnitOfWork unitOfWork,
            IRepositorioDeFabricantes repositorioDeFabricantes
        )
        {
            this.unitOfWork = unitOfWork;

            this.repositorioDeFabricantes = repositorioDeFabricantes;
        }

        public async Task<IRespostaDeCadastroDeFabricante> CadastraFabricante(ISolicitacaoDeCadastroDeFabricante solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var fabricante = new Fabricante(
                    solicitacao.Id,
                    solicitacao.Nome,
                    solicitacao.Marca,
                    solicitacao.Site
                );

                //

                await repositorioDeFabricantes.Add(fabricante);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeFabricante
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

        public async Task<IRespostaDeCadastroDeFabricante> AtualizaFabricante(int fabricanteId, ISolicitacaoDeCadastroDeFabricante solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var fabricante = await repositorioDeFabricantes.ObtemFabricante(fabricanteId);

                //

                fabricante.Id = solicitacao.Id;

                fabricante.Nome = solicitacao.Nome;

                fabricante.Marca = solicitacao.Marca;

                fabricante.Site = solicitacao.Site;

                //

                await repositorioDeFabricantes.Update(fabricante);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeFabricante
                {
                    Id = fabricanteId,
                };
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public async Task ExcluiFabricante(int fabricanteId)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var fabricante = await repositorioDeFabricantes.ObtemFabricante(fabricanteId);

                //

                await repositorioDeFabricantes.Remove(fabricante);

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
