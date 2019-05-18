using Microsoft.AspNetCore.Mvc;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Componentes
{
    [Route("cadastro/materiais/componentes")]
    [ApiController]
    public class ComponentesController : ControllerBase
    {
        private readonly IConsultaDeComponentes consultaDeComponentes;

        private readonly ICadastroDeComponentes cadastroDeComponentes;

        public ComponentesController(
            IConsultaDeComponentes consultaDeComponentes,
            ICadastroDeComponentes cadastroDeComponentes
        )
        {
            this.consultaDeComponentes = consultaDeComponentes;

            this.cadastroDeComponentes = cadastroDeComponentes;
        }

        [HttpGet]
        public async Task<IComponente[]> Get()
        {
            return await consultaDeComponentes.ObtemObservavelDeComponentes();
        }

        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        public async Task<IRespostaDeCadastroDeComponente> Post(ISolicitacaoDeCadastroDeComponente solicitacao)
        {
            var resposta = await cadastroDeComponentes.CadastraComponente(solicitacao);

            return resposta;
        }

        [HttpPut("{componenteId}")]
        public async Task<IRespostaDeCadastroDeComponente> Put(int componenteId, ISolicitacaoDeCadastroDeComponente solicitacao)
        {
            var resposta = await cadastroDeComponentes.AtualizaComponente(componenteId, solicitacao);

            return resposta;
        }

        [HttpDelete("{componenteId}")]
        public async Task Delete(int componenteId)
        {
            await cadastroDeComponentes.ExcluiComponente(componenteId);
        }
    }
}
