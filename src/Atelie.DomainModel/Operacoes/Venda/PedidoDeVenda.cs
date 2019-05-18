using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atelie.Cadastro.Modelos;
using Atelie.Comum;
using Atelie.Comum.Comercial;

namespace Atelie.Operacoes.Venda
{
    public class PedidoDeVenda : IPedidoDeVenda
    {
        public int Id { get; internal set; }

        public DateTime Data { get; internal set; }

        public virtual ICollection<ItemDePedidoDeVenda> Itens { get; internal set; }

        public virtual MeioDePagamento MeioDePagamento { get; internal set; }

        public StatusDePedidoDeVenda Status { get; internal set; }

        IItemDePedidoDeVenda[] IPedidoDeVenda.Itens => Itens.ToArray();

        IMeioDePagamento IPedidoDeVenda.MeioDePagamento => MeioDePagamento;

        public void Finaliza()
        {

        }
    }

    public class ItemDePedidoDeVenda : IItemDePedidoDeVenda
    {
        public virtual PedidoDeVenda Pedido { get; internal set; }

        public virtual TamanhoDeModelo TamanhoDeModelo { get; internal set; }

        public virtual Modelo Modelo { get; internal set; }

        public virtual Unidade Unidade { get; internal set; }

        public double Quantidade { get; internal set; }

        public decimal Valor { get; internal set; }

        public decimal Desconto { get; internal set; }

        public virtual TipoDeComercializacao TipoDeComercializacao { get; internal set; }

        IPedidoDeVenda IItemDePedidoDeVenda.Pedido => Pedido;

        ITamanhoDeModelo IItemDePedidoDeVenda.TamanhoDeModelo => TamanhoDeModelo;

        IModelo IItemDePedidoDeVenda.Modelo => Modelo;

        IUnidade IItemDePedidoDeVenda.Unidade => Unidade;

        ITipoDeComercializacao IItemDePedidoDeVenda.TipoDeComercializacao => TipoDeComercializacao;
    }

    public class TipoDeComercializacao : ITipoDeComercializacao
    {
        public string Sigla { get; internal set; }

        public string Nome { get; internal set; }

        public decimal PercentualDeLucro { get; internal set; }
    }

    public interface IRepositorioDePedidoDeVendas
    {
        Task<PedidoDeVenda> ObtemPedidoDeVenda(int id);

        Task Update(PedidoDeVenda pedidoDeVenda);
    }
}
