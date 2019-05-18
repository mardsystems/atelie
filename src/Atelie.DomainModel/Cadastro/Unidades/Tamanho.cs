using Atelie.Comum;

namespace Atelie.Cadastro.Unidades
{
    public class Tamanho : ITamanho
    {
        public virtual Unidade Unidade { get; internal set; }

        public double Quantidade { get; internal set; }

        IUnidade ITamanho.Unidade => Unidade;
    }
}
