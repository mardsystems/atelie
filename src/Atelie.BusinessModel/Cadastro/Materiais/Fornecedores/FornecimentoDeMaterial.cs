using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Unidades;

namespace Atelie.Cadastro.Materiais.Fornecedores
{
    public interface IFornecimentoDeMaterial
    {
        IFornecedor Fornecedor { get; }

        IMaterial Material { get; }

        /// <summary>
        /// Nome do material utilizado na comercialização deste fornecedor.
        /// </summary>
        string NomeComercial { get; }

        ///// <summary>
        ///// Somente cores do catálogo deste material.
        ///// </summary>
        //ICorDeFabricante Cor { get; }

        //ITamanho TamanhoMinimoPorPedido { get; }

        decimal? UltimoPreco { get; }
    }
}
