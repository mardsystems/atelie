using Microsoft.AspNetCore.Mvc;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    [Route("cadastro/materiais/fabricantes/fabricacoesDeComponente")]
    [ApiController]
    public class FabricacoesDeComponentesController : ControllerBase
    {
        private readonly IConsultaDeFabricacoesDeComponentes consultaDeFabricacoesDeComponentes;

        private readonly ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes;

        public FabricacoesDeComponentesController(
            IConsultaDeFabricacoesDeComponentes consultaDeFabricacoesDeComponentes,
            ICadastroDeFabricacoesDeComponentes cadastroDeFabricacoesDeComponentes
        )
        {
            this.consultaDeFabricacoesDeComponentes = consultaDeFabricacoesDeComponentes;

            this.cadastroDeFabricacoesDeComponentes = cadastroDeFabricacoesDeComponentes;
        }

        [HttpGet]
        public async Task<IFabricacaoDeComponente[]> Get()
        {
            return await consultaDeFabricacoesDeComponentes.ObtemObservavelDeFabricacoesDeComponentes();
        }

        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        public async Task<IRespostaDeCadastroDeFabricacaoDeComponente> Post(SolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao)
        {
            var resposta = await cadastroDeFabricacoesDeComponentes.CadastraFabricacaoDeComponente(solicitacao);

            return resposta;
        }

        [HttpPut]
        public async Task<IRespostaDeCadastroDeFabricacaoDeComponente> Put(int fabricanteId, int componenteId, SolicitacaoDeCadastroDeFabricacaoDeComponente solicitacao)
        {
            var resposta = await cadastroDeFabricacoesDeComponentes.AtualizaFabricacaoDeComponente(fabricanteId, componenteId, solicitacao);

            return resposta;
        }

        [HttpDelete]
        public async Task Delete(int fabricanteId, int componenteId)
        {
            await cadastroDeFabricacoesDeComponentes.ExcluiFabricacaoDeComponente(fabricanteId, componenteId);

        }
    }
}
