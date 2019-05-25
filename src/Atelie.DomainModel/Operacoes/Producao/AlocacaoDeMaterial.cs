using Atelie.Cadastro.Materiais;

namespace Atelie.Operacoes.Producao
{
    public class AlocacaoDeMaterial
    {
        public virtual Material Material { get; internal set; }

        public double Quantidade { get; internal set; }

        public decimal ValorDeEstoque { get; internal set; }
    }
}