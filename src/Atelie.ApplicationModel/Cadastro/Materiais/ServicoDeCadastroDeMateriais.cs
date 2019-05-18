using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelie.Cadastro.Materiais
{
    public class ServicoDeCadastroDeMateriais : ICadastroDeMateriais
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepositorioDeMateriais repositorioDeMateriais;

        private readonly IRepositorioDeFabricantes repositorioDeFabricantes;

        private readonly IRepositorioDeComponentes repositorioDeComponentes;

        public ServicoDeCadastroDeMateriais(
            IUnitOfWork unitOfWork,
            IRepositorioDeMateriais repositorioDeMateriais,
            IRepositorioDeFabricantes repositorioDeFabricantes,
            IRepositorioDeComponentes repositorioDeComponentes
        )
        {
            this.unitOfWork = unitOfWork;

            this.repositorioDeMateriais = repositorioDeMateriais;

            this.repositorioDeFabricantes = repositorioDeFabricantes;

            this.repositorioDeComponentes = repositorioDeComponentes;
        }

        public async Task<IRespostaDeCadastroDeMaterial> CadastraMaterial(ISolicitacaoDeCadastroDeMaterial solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var fabricante = await repositorioDeFabricantes.ObtemFabricante(solicitacao.FabricanteId);

                var componente = await repositorioDeComponentes.ObtemComponente(solicitacao.ComponenteId);

                var material = new Material(
                    solicitacao.Id,
                    solicitacao.Nome,
                    solicitacao.Descricao,
                    solicitacao.CustoPadrao,
                    fabricante,
                    componente
                );

                //

                await repositorioDeMateriais.Add(material);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeMaterial
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

        public async Task<IRespostaDeCadastroDeMaterial> AtualizaMaterial(int materialId, ISolicitacaoDeCadastroDeMaterial solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var material = await repositorioDeMateriais.ObtemMaterial(materialId);

                //

                var fabricante = await repositorioDeFabricantes.ObtemFabricante(solicitacao.FabricanteId);

                var componente = await repositorioDeComponentes.ObtemComponente(solicitacao.ComponenteId);

                //

                material.Id = solicitacao.Id;

                material.Nome = solicitacao.Nome;

                material.Fabricante = fabricante;

                material.Componente = componente;

                //

                await repositorioDeMateriais.Update(material);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeMaterial
                {
                    Id = materialId,
                };
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public async Task ExcluiMaterial(int materialId)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var material = await repositorioDeMateriais.ObtemMaterial(materialId);

                //

                await repositorioDeMateriais.Remove(material);

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
