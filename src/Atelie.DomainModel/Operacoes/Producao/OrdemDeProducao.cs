using Atelie.Cadastro.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Operacoes.Producao
{
    public class OrdemDeProducao
    {
        public StatusDeOrdemDeProducao Status { get; internal set; }

        public virtual ICollection<ItemDeOrdemDeProducao> Itens { get; internal set; }

        public OrdemDeProducao()
        {
            Itens = new HashSet<ItemDeOrdemDeProducao>();
        }

        public IEnumerable<ItemDeOrdemDeProducao> ObtemItemsPorTamanho(TamanhoDeModelo tamanho)
        {
            return Itens.Where(p => p.Tamanho == tamanho);
        }

        public ItemDeOrdemDeProducao AdicionaItem(Modelo modelo, TamanhoDeModelo tamanho, int quantidade)
        {
            var item = new ItemDeOrdemDeProducao(modelo, tamanho, quantidade);

            return item;
        }

        public void Finaliza()
        {
            Status = StatusDeOrdemDeProducao.Finalizada;
        }
    }

    public interface IRepositorioDeOrdemDeProducao
    {
        Task<OrdemDeProducao> ObtemOrdemDeProducao(int id);

        Task Update(OrdemDeProducao ordemDeProducao);
    }
}
