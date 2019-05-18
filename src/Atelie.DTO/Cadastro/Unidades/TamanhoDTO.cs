using Atelie.Comum;

namespace Atelie.Cadastro.Unidades
{
    public class TamanhoDTO : ITamanho
    {
        public UnidadeDTO Unidade { get; set; }

        public double Quantidade { get; set; }

        IUnidade ITamanho.Unidade => Unidade;
    }
}
