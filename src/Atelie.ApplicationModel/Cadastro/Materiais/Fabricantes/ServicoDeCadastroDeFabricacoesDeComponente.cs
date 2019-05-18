using Atelie.Cadastro.Materiais.Componentes;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class ServicoDeCadastroDeFabricacoesDeComponentes : ICadastroDeFabricacoesDeComponentes
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IRepositorioDeFabricacoesDeComponentes repositorioDeFabricacoesDeComponentes;

        private readonly IRepositorioDeFabricantes repositorioDeFabricantes;

        private readonly IRepositorioDeComponentes repositorioDeComponentes;

        public ServicoDeCadastroDeFabricacoesDeComponentes(
            IUnitOfWork unitOfWork,
            IRepositorioDeFabricacoesDeComponentes repositorioDeFabricacoesDeComponentes,
            IRepositorioDeFabricantes repositorioDeFabricantes,
            IRepositorioDeComponentes repositorioDeComponentes
        )
        {
            this.unitOfWork = unitOfWork;

            this.repositorioDeFabricacoesDeComponentes = repositorioDeFabricacoesDeComponentes;

            this.repositorioDeFabricantes = repositorioDeFabricantes;

            this.repositorioDeComponentes = repositorioDeComponentes;
        }

        public async Task<IRespostaDeCadastroDeFabricacaoDeComponente> CadastraFabricacaoDeComponente(ISolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var fabricante = await repositorioDeFabricantes.ObtemFabricante(solicitacao.FabricanteId);

                var componente = await repositorioDeComponentes.ObtemComponente(solicitacao.ComponenteId);

                var fabricacaoDeComponente = new FabricacaoDeComponente(
                    fabricante,
                    componente
                );

                //

                await repositorioDeFabricacoesDeComponentes.Add(fabricacaoDeComponente);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeFabricacaoDeComponente
                {

                };
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public async Task<IRespostaDeCadastroDeFabricacaoDeComponente> AtualizaFabricacaoDeComponente(int fabricacaoId, int componenteId, ISolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var fabricacaoDeComponente = await repositorioDeFabricacoesDeComponentes.ObtemFabricacaoDeComponente(fabricacaoId, componenteId);

                var fabricante = await repositorioDeFabricantes.ObtemFabricante(solicitacao.FabricanteId);

                var componente = await repositorioDeComponentes.ObtemComponente(solicitacao.ComponenteId);

                //

                fabricacaoDeComponente.Fabricante = fabricante;

                fabricacaoDeComponente.Componente = componente;

                //

                await repositorioDeFabricacoesDeComponentes.Update(fabricacaoDeComponente);

                //

                await unitOfWork.Commit();

                //

                return new RespostaDeCadastroDeFabricacaoDeComponente
                {

                };
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public async Task ExcluiFabricacaoDeComponente(int fabricacaoId, int componenteId)
        {
            await unitOfWork.BeginTransaction();

            try
            {
                var fabricacaoDeComponente = await repositorioDeFabricacoesDeComponentes.ObtemFabricacaoDeComponente(fabricacaoId, componenteId);

                //

                await repositorioDeFabricacoesDeComponentes.Remove(fabricacaoDeComponente);

                //

                await unitOfWork.Commit();
            }
            catch (Exception e)
            {
                await unitOfWork.Rollback();

                throw;
            }
        }

        public Task ExcluiFabricacaoDeComponentePorFabricante(int fabricanteId)
        {
            throw new NotImplementedException();
        }

        public Task<IRespostaDeCadastroDeCatalogo> CadastraCatalogo(ISolicitacaoDeCadastroDeCatalogo solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task<IRespostaDeCadastroDeCatalogo> AtualizaCatalogo(int fabricanteId, int componenteId, string nome, ISolicitacaoDeCadastroDeCatalogo solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task ExcluiCatalogo(int fabricanteId, int componenteId, string nome)
        {
            throw new NotImplementedException();
        }

        public Task<IRespostaDeDefinicaoDeCorNoCatalogo> DefineCorNoCatalogo(ISolicitacaoDeDefinicaoDeCorNoCatalogo solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDefinicaoDeCorDoCatalogo(int fabricanteId, int componenteId, string catalogoNome, string embalagemNome)
        {
            throw new NotImplementedException();
        }

        public Task<IRespostaDeDisponibilizacaoDeEmbalagemNoCatalogo> DisponibilizaEmbalagemNoCatalogo(ISolicitacaoDeDisponibilizacaoDeEmbalagemNoCatalogo solicitacao)
        {
            throw new NotImplementedException();
        }

        public Task ExcluiDisponibilidadeDeEmbalagemDoCatalogo(int fabricanteId, int componenteId, string catalogoNome, string embalagemNome)
        {
            throw new NotImplementedException();
        }
    }
}
