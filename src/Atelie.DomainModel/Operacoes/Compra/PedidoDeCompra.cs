using Atelie.Cadastro.Materiais.Fornecedores;
using Atelie.Comum.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atelie.Operacoes.Compra
{
    public class PedidoDeCompra : IPedidoDeCompra
    {
        public int Id { get; internal set; }

        public DateTime Data { get; internal set; }

        public virtual ICollection<ItemDePedidoDeCompra> Itens { get; internal set; }

        public virtual MeioDePagamento MeioDePagamento { get; internal set; }

        public virtual Fornecedor Fornecedor { get; internal set; }

        public StatusDePedidoDeCompra Status { get; internal set; }

        public PedidoDeCompra()
        {
            Itens = new HashSet<ItemDePedidoDeCompra>();
        }

        IItemDePedidoDeCompra[] IPedidoDeCompra.Itens => Itens.ToArray();

        IMeioDePagamento IPedidoDeCompra.MeioDePagamento => MeioDePagamento;

        IFornecedor IPedidoDeCompra.Fornecedor => Fornecedor;

        public void Finaliza()
        {
            // TODO: dá entrada no Estoque.
        }
    }
}
