using Atelie.Cadastro.Modelos;

namespace Atelie.Operacoes.Estoque
{
    public interface IEstoqueDeModelo : IEstoque
    {
        IModelo Modelo { get; }

        ITamanhoDeModelo TamanhoDeModelo { get; }
    }
}
