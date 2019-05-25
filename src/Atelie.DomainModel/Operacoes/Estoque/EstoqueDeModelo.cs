using Atelie.Cadastro.Modelos;

namespace Atelie.Operacoes.Estoque
{
    public class EstoqueDeModelo : Estoque
    {
        public virtual Modelo Modelo { get; internal set; }

        public virtual TamanhoDeModelo TamanhoDeModelo { get; internal set; }
    }
}
