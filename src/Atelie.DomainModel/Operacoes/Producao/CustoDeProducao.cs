﻿using System;

namespace Atelie.Operacoes.Producao
{
    public class CustoDeProducao
    {
        public decimal CustoDeComposicao { get; internal set; }

        public decimal CustoDeConfeccao { get; internal set; }

        public decimal Valor { get { return CustoDeComposicao + CustoDeConfeccao; } }

        /// <summary>
        /// Preço calculado a base do custo (10x).
        /// O valor deve ser arrendodado para zero na unidade simples.
        /// </summary>
        public decimal x10 { get { return Math.Round(Valor * 10, 0); } }

        public CustoDeProducao()
        {

        }

        public CustoDeProducao(decimal valor)
        {
            CustoDeComposicao = valor / 2;

            CustoDeConfeccao = valor / 2;
        }
    }
}
