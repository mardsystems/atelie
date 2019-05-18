using System;

namespace Atelie.Operacoes.Producao
{
    public class CustoDeProducao : ICustoDeProducao
    {
        public decimal CustoDeComposicao { get; internal set; }

        public decimal CustoDeConfeccao { get; internal set; }

        public decimal Valor { get { return CustoDeComposicao + CustoDeConfeccao; } }

        /// <summary>
        /// Preço calculado a base do custo (10x).
        /// O valor deve ser arrendodado para zero na unidade simples.
        /// </summary>
        public decimal x10 { get { return Math.Round(Valor * 10, 0); } }
    }
}
