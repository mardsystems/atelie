using Atelie.Comum;
using System;

namespace Atelie.Operacoes.Estoque
{
    public interface IEstoque
    {
        int Quantidade { get; }

        int Reserva { get; }

        int Minimo { get; }

        int Maximo { get; }

        decimal Valor { get; }

        StatusDeEstoque Status { get; }

        IRegistroDeEstoque[] Registros { get; }
    }

    public interface IRegistroDeEstoque
    {
        IEstoque Estoque { get; }

        DateTime Data { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        IUnidade Unidade { get; }

        /// <summary>
        /// Ver Tamanho.
        /// </summary>
        double Quantidade { get; }

        decimal ValorUnitario { get; }

        TipoDeRegistroDeEstoque Tipo { get; }
    }
}
