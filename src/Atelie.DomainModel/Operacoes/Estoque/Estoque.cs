using System;
using System.Collections.Generic;
using System.Linq;
using Atelie.Comum;

namespace Atelie.Operacoes.Estoque
{
    public abstract class Estoque
    {
        public int Quantidade { get; internal set; }

        public int Reserva { get; internal set; }

        public int Minimo { get; internal set; }

        public int Maximo { get; internal set; }

        public decimal Valor { get; internal set; }

        public StatusDeEstoque Status { get; internal set; }

        public ICollection<RegistroDeEstoque> Registros { get; internal set; }

        public Estoque()
        {
            Registros = new HashSet<RegistroDeEstoque>();
        }
    }

    public class RegistroDeEstoque
    {
        public virtual Estoque Estoque { get; internal set; }

        public DateTime Data { get; internal set; }

        public virtual Unidade Unidade { get; internal set; }

        public double Quantidade { get; internal set; }

        public decimal ValorUnitario { get; internal set; }

        public TipoDeRegistroDeEstoque Tipo { get; internal set; }
    }

    public interface IRepositorioDeEstoques
    {

    }
}
