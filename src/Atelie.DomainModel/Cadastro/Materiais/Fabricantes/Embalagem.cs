using Atelie.Comum;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class Embalagem : IEmbalagem
    {
        public virtual Unidade Unidade { get; internal set; }

        public double Valor { get; internal set; }

        public virtual Unidade UnidadeBase { get; internal set; }

        public string UnidadeSigla { get; internal set; }

        public string UnidadeBaseSigla { get; internal set; }

        IUnidade IEmbalagem.Unidade => Unidade;

        IUnidade IEmbalagem.UnidadeBase => UnidadeBase;
    }
}
