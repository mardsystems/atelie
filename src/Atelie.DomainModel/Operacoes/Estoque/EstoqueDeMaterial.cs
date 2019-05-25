using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Fabricantes;

namespace Atelie.Operacoes.Estoque
{
    public class EstoqueDeMaterial : Estoque
    {
        public virtual Material Material { get; internal set; }

        //public virtual CorDeFabricante Cor { get; internal set; }
    }
}
