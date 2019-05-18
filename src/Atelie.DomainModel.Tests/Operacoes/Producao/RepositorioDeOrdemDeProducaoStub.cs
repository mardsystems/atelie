using Atelie.Cadastro.Modelos;
using System.Threading.Tasks;

namespace Atelie.Operacoes.Producao
{
    public class RepositorioDeOrdemDeProducaoStub : IRepositorioDeOrdemDeProducao
    {
        private OrdemDeProducao ordemDeProducao;

        public async Task<OrdemDeProducao> ObtemOrdemDeProducao(int id)
        {
            //if (id == 0)
            //{
            //    throw new InvalidOperationException();
            //}

            if (ordemDeProducao != null)
            {
                return ordemDeProducao;
            }

            var calcaJeans = new Modelo("ABC");

            var m = new TamanhoDeModelo("M");

            ordemDeProducao = new OrdemDeProducao();

            ordemDeProducao.AdicionaItem(null, m, 10); //calcaJeans

            return ordemDeProducao;
        }

        public async Task Update(OrdemDeProducao ordemDeProducao)
        {
            this.ordemDeProducao = ordemDeProducao;
        }
    }
}
