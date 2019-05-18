using Atelie.Cadastro.Modelos;

namespace Atelie.Operacoes.Estoque
{
    public class EstoqueDeModelo : Estoque, IEstoqueDeModelo
    {
        public virtual Modelo Modelo { get; internal set; }

        public virtual TamanhoDeModelo TamanhoDeModelo { get; internal set; }

        IModelo IEstoqueDeModelo.Modelo => Modelo;

        ITamanhoDeModelo IEstoqueDeModelo.TamanhoDeModelo => TamanhoDeModelo;
    }
}
