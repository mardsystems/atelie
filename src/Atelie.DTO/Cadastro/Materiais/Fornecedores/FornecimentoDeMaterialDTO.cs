using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Unidades;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public class FornecimentoDeMaterialDTO : IFornecimentoDeMaterial
    {
        public FornecedorDTO Fornecedor { get; set; }

        public MaterialDTO Material { get; set; }

        public string NomeComercial { get; set; }

        public CorDeFabricanteDTO Cor { get; set; }

        public TamanhoDTO TamanhoMinimoPorPedido { get; set; }

        public decimal? UltimoPreco { get; set; }

        IFornecedor IFornecimentoDeMaterial.Fornecedor => Fornecedor;

        IMaterial IFornecimentoDeMaterial.Material => Material;

        ICorDeFabricante IFornecimentoDeMaterial.Cor => Cor;

        ITamanho IFornecimentoDeMaterial.TamanhoMinimoPorPedido => TamanhoMinimoPorPedido;
    }
}
