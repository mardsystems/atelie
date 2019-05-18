using Atelie.Comum;

namespace Atelie.Cadastro.Unidades
{
    public interface ITamanho
    {
        IUnidade Unidade { get; }

        double Quantidade { get; }
    }
}
