using System.Threading.Tasks;

namespace Atelie.Operacoes.Venda
{
    public interface IVendaDeModelos
    {
        Task IniciaVenda();

        Task FinalizaVenda(int id);
    }
}
