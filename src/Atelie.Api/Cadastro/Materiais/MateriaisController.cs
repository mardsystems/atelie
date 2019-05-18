using Microsoft.AspNetCore.Mvc;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais
{
    [Route("cadastro/[controller]")]
    [ApiController]
    public class MateriaisController : ControllerBase
    {
        private readonly IConsultaDeMateriais consultaDeMateriais;

        private readonly ICadastroDeMateriais cadastroDeMateriais;

        public MateriaisController(
            IConsultaDeMateriais consultaDeMateriais,
            ICadastroDeMateriais cadastroDeMateriais
        )
        {
            this.consultaDeMateriais = consultaDeMateriais;

            this.cadastroDeMateriais = cadastroDeMateriais;
        }

        [HttpGet]
        public async Task<IMaterial[]> Get()
        {
            return await consultaDeMateriais.ObtemObservavelDeMateriais();
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IRespostaDeCadastroDeMaterial> Post(SolicitacaoDeCadastroDeMaterial solicitacao)
        {
            var resposta = await cadastroDeMateriais.CadastraMaterial(solicitacao);

            return resposta;
        }

        [HttpPut("{materialId}")]
        public async Task<IRespostaDeCadastroDeMaterial> Put(int materialId, SolicitacaoDeCadastroDeMaterial solicitacao)
        {
            var resposta = await cadastroDeMateriais.AtualizaMaterial(materialId, solicitacao);

            return resposta;
        }

        [HttpDelete("{materialId}")]
        public async Task Delete(int materialId)
        {
            await cadastroDeMateriais.ExcluiMaterial(materialId);
        }
    }
}
