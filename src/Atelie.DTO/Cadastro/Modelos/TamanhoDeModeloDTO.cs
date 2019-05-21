using System;
using System.Collections.Generic;
using System.Text;

namespace Atelie.Cadastro.Modelos
{
    public class TamanhoDeModeloDTO : ITamanhoDeModelo
    {
        public string Sigla { get; set; }

        public string Nome { get; set; }

        public int Posicao { get; set; }
    }
}
