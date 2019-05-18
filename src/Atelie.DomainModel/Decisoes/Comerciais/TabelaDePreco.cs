using Atelie.Cadastro.Modelos;
using System.Collections.Generic;

namespace Atelie.Decisoes.Comerciais
{
    public class TabelaDePreco
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        public virtual EstrategiaDePreco EstrategiaDePreco { get; internal set; }

        public virtual ICollection<ItemDeTabelaDePreco> Itens { get; internal set; }

        public TabelaDePreco()
        {
            Itens = new HashSet<ItemDeTabelaDePreco>();
        }
    }

    public class ItemDeTabelaDePreco
    {
        public virtual TabelaDePreco TabelaDePreco { get; internal set; }

        public virtual Modelo Modelo { get; internal set; }

        public decimal PrecoDeVarejo { get { return TabelaDePreco.EstrategiaDePreco.ValorDeVarejo(); } }

        public decimal PrecoDeAtacado { get { return TabelaDePreco.EstrategiaDePreco.ValorDeAtacado(); } }

        public decimal PrecoDeConsignacao { get { return TabelaDePreco.EstrategiaDePreco.ValorDeConsignacao(); } }
    }

    public abstract class EstrategiaDePreco
    {
        /// <summary>
        /// 0.90 ou 0.40
        /// </summary>
        public decimal PercentualDePrecoDeAtacado { get; internal set; }

        /// <summary>
        /// 1.10 (10%).
        /// </summary>
        public decimal PercentualDePrecoDeConsignacao { get; internal set; }

        public abstract decimal ValorDeVarejo();

        public abstract decimal ValorDeAtacado();

        public abstract decimal ValorDeConsignacao();
    }

    public class EstrategiaDePrecoNova : EstrategiaDePreco
    {
        public TabelaDePreco TabelaDePreco { get; }

        public PrecoDePrateleiraDesejado PrecoDePrateleiraDesejado { get; }

        public PrecoDeConsignacao PrecoDeConsignacao { get; }

        public override decimal ValorDeVarejo()
        {
            return PrecoDePrateleiraDesejado.Valor;
        }

        /// <summary>
        /// 0.90 <= 1 / 1.1
        /// </summary>
        public override decimal ValorDeAtacado()
        {
            return ValorDeConsignacao() * PercentualDePrecoDeAtacado;
        }

        public override decimal ValorDeConsignacao()
        {
            return PrecoDeConsignacao.Valor;
        }
    }

    public class EstrategiaDePrecoAntiga : EstrategiaDePreco
    {
        public PrecoDePrateleiraDesejado PrecoDePrateleiraDesejado { get; }

        public EstrategiaDePrecoAntiga(PrecoDePrateleiraDesejado precoDePrateleiraDesejado)
        {
            PrecoDePrateleiraDesejado = precoDePrateleiraDesejado;
        }

        public override decimal ValorDeVarejo()
        {
            return PrecoDePrateleiraDesejado.Valor;
        }

        /// <summary>
        /// 0.40 <= 1 / 2.5
        /// </summary>
        public override decimal ValorDeAtacado()
        {
            return ValorDeVarejo() * PercentualDePrecoDeAtacado;
        }

        public override decimal ValorDeConsignacao()
        {
            return ValorDeAtacado() * PercentualDePrecoDeConsignacao;
        }
    }
}
