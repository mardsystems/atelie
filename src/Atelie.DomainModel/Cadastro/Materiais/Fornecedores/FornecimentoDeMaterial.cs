using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Unidades;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public class FornecimentoDeMaterial : IFornecimentoDeMaterial
    {
        public virtual Fornecedor Fornecedor { get; internal set; }

        public virtual Material Material { get; internal set; }

        public string NomeComercial { get; internal set; }

        public virtual CorDeFabricante Cor { get; internal set; }

        public virtual Tamanho TamanhoMinimoPorPedido { get; internal set; }

        public decimal? UltimoPreco { get; internal set; }

        IFornecedor IFornecimentoDeMaterial.Fornecedor => Fornecedor;

        IMaterial IFornecimentoDeMaterial.Material => Material;

        ICorDeFabricante IFornecimentoDeMaterial.Cor => Cor;

        ITamanho IFornecimentoDeMaterial.TamanhoMinimoPorPedido => TamanhoMinimoPorPedido;

        public int FornecedorId { get; internal set; }

        public int MaterialId { get; internal set; }
    }
}
