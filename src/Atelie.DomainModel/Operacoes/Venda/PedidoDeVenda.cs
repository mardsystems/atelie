using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atelie.Cadastro.Modelos;
using Atelie.Comum;
using Atelie.Comum.Comercial;

namespace Atelie.Operacoes.Venda
{
    public class PedidoDeVenda
    {
        public int Id { get; internal set; }

        public DateTime Data { get; internal set; }

        public virtual ICollection<ItemDePedidoDeVenda> Itens { get; internal set; }

        public virtual MeioDePagamento MeioDePagamento { get; internal set; }

        public StatusDePedidoDeVenda Status { get; internal set; }

        public void Finaliza()
        {

        }
    }

    public class ItemDePedidoDeVenda
    {
        public virtual PedidoDeVenda Pedido { get; internal set; }

        public virtual TamanhoDeModelo TamanhoDeModelo { get; internal set; }

        public virtual Modelo Modelo { get; internal set; }

        public virtual Unidade Unidade { get; internal set; }

        public double Quantidade { get; internal set; }

        public decimal Valor { get; internal set; }

        public decimal Desconto { get; internal set; }

        public virtual TipoDeComercializacao TipoDeComercializacao { get; internal set; }
    }

    public class TipoDeComercializacao
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
