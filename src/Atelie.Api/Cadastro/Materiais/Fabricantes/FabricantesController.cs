using Microsoft.AspNetCore.Mvc;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    [Route("cadastro/materiais/fabricantes")]
    [ApiController]
    public class FabricantesController : ControllerBase
    {
        private readonly IConsultaDeFabricantes consultaDeFabricantes;

        private readonly ICadastroDeFabricantes cadastroDeFabricantes;

        private readonly IConsultaDeFabricacoesDeComponentes consultaDeFabricacoesDeComponentes;

        private readonly ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes;

        public FabricantesController(
            IConsultaDeFabricantes consultaDeFabricantes,
            ICadastroDeFabricantes cadastroDeFabricantes,
            IConsultaDeFabricacoesDeComponentes consultaDeFabricacoesDeComponentes,
            ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes
        )
        {
            this.consultaDeFabricantes = consultaDeFabricantes;

            this.cadastroDeFabricantes = cadastroDeFabricantes;

            this.consultaDeFabricacoesDeComponentes = consultaDeFabricacoesDeComponentes;

            this.cadastroDeFabricacoesDeComponentes = cadastroDeFabricacoesDeComponentes;
        }

        [HttpGet]
        public async Task<IFabricante[]> Get()
        {
            return await consultaDeFabricantes.ObtemObservavelDeFabricantes();
        }

        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        public async Task<IRespostaDeCadastroDeFabricante> Post(SolicitacaoDeCadastroDeFabricante solicitacao)
        {
            var resposta = await cadastroDeFabricantes.CadastraFabricante(solicitacao);

            return resposta;
        }

        [HttpPut("{fabricanteId}")]
        public async Task<IRespostaDeCadastroDeFabricante> Put(int fabricanteId, SolicitacaoDeCadastroDeFabricante solicitacao)
        {
            var resposta = await cadastroDeFabricantes.AtualizaFabricante(fabricanteId, solicitacao);

            return resposta;
        }

        [HttpDelete("{fabricanteId}")]
        public async Task Delete(int fabricanteId)
        {
            await cadastroDeFabricantes.ExcluiFabricante(fabricanteId);

        }

        //

        [HttpGet("{fabricanteId}/componentesFabricados")]
        public async Task<IFabricacaoDeComponente[]> Get(int fabricanteId)
        {
            return await consultaDeFabricacoesDeComponentes.ObtemObservavelDeFabricacoesDeComponentesPorFabricante(fabricanteId);
        }

        [HttpPost("{fabricanteId}/componentesFabricados")]
        public async Task<IRespostaDeCadastroDeFabricacaoDeComponente> PostFabricacaoDeComponente(SolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao)
        {
            var resposta = await cadastroDeFabricacoesDeComponentes.CadastraFabricacaoDeComponente(solicitacao);

            return resposta;
        }

        [HttpPut("{fabricanteId}/componentesFabricados/{componenteId}")]
        public async Task<IRespostaDeCadastroDeFabricacaoDeComponente> PutFabricacaoDeComponente(int fabricanteId, int componenteId, SolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao)
        {
            var resposta = await cadastroDeFabricacoesDeComponentes.AtualizaFabricacaoDeComponente(fabricanteId, componenteId, solicitacao);

            return resposta;
        }

        [HttpDelete("{fabricanteId}/componentesFabricados")]
        public async Task DeleteFabricacaoDeComponente(int fabricanteId)
        {
            await cadastroDeFabricacoesDeComponentes.ExcluiFabricacaoDeComponentePorFabricante(fabricanteId);
        }

        [HttpDelete("{fabricanteId}/componentesFabricados/{componenteId}")]
        public async Task DeleteFabricacaoDeComponente(int fabricanteId, int componenteId)
        {
            await cadastroDeFabricacoesDeComponentes.ExcluiFabricacaoDeComponente(fabricanteId, componenteId);
        }
    }
}
