using System;
using System.Collections.Generic;
using System.Text;

namespace Atelie.Operacoes.Producao
{
    public class CustoDeProducaoDTO : ICustoDeProducao
    {
        public decimal CustoDeComposicao { get; set; }

        public decimal CustoDeConfeccao { get; set; }

        public decimal Valor { get; set; }

        public decimal x10 { get; set; }
    }
}
