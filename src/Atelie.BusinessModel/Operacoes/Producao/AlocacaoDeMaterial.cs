using Atelie.Cadastro.Materiais;

namespace Atelie.Operacoes.Producao
{
    public interface IAlocacaoDeMaterial
    {
        IMaterial Material { get; }

        double Quantidade { get; }
    }
}
