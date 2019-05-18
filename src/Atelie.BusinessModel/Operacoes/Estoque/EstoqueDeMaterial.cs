using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Fabricantes;

namespace Atelie.Operacoes.Estoque
{
    public interface IEstoqueDeMaterial : IEstoque
    {
        IMaterial Material { get; }

        ICorDeFabricante Cor { get; }
    }
}
