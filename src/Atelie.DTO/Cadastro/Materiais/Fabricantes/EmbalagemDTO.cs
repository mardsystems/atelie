using Atelie.Comum;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class EmbalagemDTO : IEmbalagem
    {
        public UnidadeDTO Unidade { get; set; }

        public double Valor { get; set; }

        public UnidadeDTO UnidadeBase { get; set; }

        IUnidade IEmbalagem.Unidade => Unidade;

        IUnidade IEmbalagem.UnidadeBase => UnidadeBase;
    }
}
