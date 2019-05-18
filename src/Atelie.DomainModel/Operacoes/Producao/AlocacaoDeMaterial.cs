using Atelie.Cadastro.Materiais;

namespace Atelie.Operacoes.Producao
{
    public class AlocacaoDeMaterial : IAlocacaoDeMaterial
    {
        public virtual Material Material { get; internal set; }

        public double Quantidade { get; internal set; }

        public decimal ValorDeEstoque { get; internal set; }

        IMaterial IAlocacaoDeMaterial.Material => Material;
    }
}