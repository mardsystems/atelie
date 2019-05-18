using System.Threading.Tasks;

namespace Atelie.Operacoes.Producao
{
    public interface IProducaoDeModelos
    {
        Task IniciaProducao();

        Task FinalizaProducao(int id);
    }
}
