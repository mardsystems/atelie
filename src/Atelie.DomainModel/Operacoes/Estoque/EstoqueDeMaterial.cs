using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Fabricantes;

namespace Atelie.Operacoes.Estoque
{
    public class EstoqueDeMaterial : Estoque, IEstoqueDeMaterial
    {
        public virtual Material Material { get; internal set; }

        //public virtual CorDeFabricante Cor { get; internal set; }

        IMaterial IEstoqueDeMaterial.Material => Material;

        //ICorDeFabricante IEstoqueDeMaterial.Cor => Cor;
    }
}
