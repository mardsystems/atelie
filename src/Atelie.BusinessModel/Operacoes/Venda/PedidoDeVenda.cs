using Atelie.Cadastro.Modelos;
using Atelie.Comum;
using Atelie.Comum.Comercial;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atelie.Operacoes.Venda
{
    public interface IPedidoDeVenda
    {
        int Id { get; }

        DateTime Data { get; }

        IItemDePedidoDeVenda[] Itens { get; }

        IMeioDePagamento MeioDePagamento { get; }

        //ICliente Cliente { get; }

        StatusDePedidoDeVenda Status { get; }
    }

    public interface IItemDePedidoDeVenda
    {
        IPedidoDeVenda Pedido { get; }

        ITamanhoDeModelo TamanhoDeModelo { get; }

        IModelo Modelo { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        IUnidade Unidade { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        double Quantidade { get; }

        decimal Valor { get; }

        decimal Desconto { get; }

        ITipoDeComercializacao TipoDeComercializacao { get; }
    }

    public interface ITipoDeComercializacao
    {
        string Sigla { get; }

        string Nome { get; }

        decimal PercentualDeLucro { get; }
    }
}
