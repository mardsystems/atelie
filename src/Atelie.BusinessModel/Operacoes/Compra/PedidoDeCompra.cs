using Atelie.Cadastro.Materiais;
using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Materiais.Fornecedores;
using Atelie.Comum;
using Atelie.Comum.Comercial;
using System;

namespace Atelie.Operacoes.Compra
{
    public interface IPedidoDeCompra
    {
        int Id { get; }

        DateTime Data { get; }

        IItemDePedidoDeCompra[] Itens { get; }

        IMeioDePagamento MeioDePagamento { get; }

        IFornecedor Fornecedor { get; }

        StatusDePedidoDeCompra Status { get; }
    }

    public interface IItemDePedidoDeCompra
    {
        IPedidoDeCompra Pedido { get; }

        IMaterial Material { get; }

        ICorDeFabricante Cor { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        IUnidade Unidade { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        double Quantidade { get; }

        decimal Valor { get; }
    }
}
