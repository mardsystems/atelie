using Microsoft.AspNetCore.Mvc;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Atelie.Decisoes.Comerciais
{
    [Route("decisoes/comerciais")]
    [ApiController]
    public class PlanosComerciaisController : ControllerBase
    {
        private readonly IConsultaDePlanosComerciais consultaDePlanosComerciais;

        private readonly IPlanejamentoComercial planejamentoComercial;

        public PlanosComerciaisController(
            IConsultaDePlanosComerciais consultaDePlanosComerciais,
            IPlanejamentoComercial planejamentoComercial
        )
        {
            this.consultaDePlanosComerciais = consultaDePlanosComerciais;

            this.planejamentoComercial = planejamentoComercial;
        }

        [HttpGet]
        public async Task<IPlanoComercial[]> Get()
        {
            return await consultaDePlanosComerciais.ObtemObservavelDePlanosComerciais();
        }

        //[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IRespostaDeCriacaoDePlanoComercial> Post(SolicitacaoDeCriacaoDePlanoComercial solicitacao)
        {
            var resposta = await planejamentoComercial.CriaPlanoComercial(solicitacao);

            return resposta;
        }

        [HttpPut("{planoComercialId}")]
        public async Task<IRespostaDeCriacaoDePlanoComercial> Put(string planoComercialId, SolicitacaoDeCriacaoDePlanoComercial solicitacao)
        {
            var resposta = await planejamentoComercial.AtualizaPlanoComercial(planoComercialId, solicitacao);

            return resposta;
        }

        [HttpDelete("{planoComercialId}")]
        public async Task Delete(string planoComercialId)
        {
            await planejamentoComercial.ExcluiPlanoComercial(planoComercialId);
        }
    }
}
