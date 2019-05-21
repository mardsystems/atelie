using Atelie.Cadastro.Materiais;

namespace Atelie.Cadastro.Modelos.Producao
{
    public class NecessidadeDeMaterial : INecessidadeDeMaterial
    {
        public virtual Modelo Modelo { get; internal set; }

        public virtual TamanhoDeModelo TamanhoDeModelo { get; internal set; }

        public virtual Material Material { get; internal set; }

        //public virtual CorDeFabricante Cor { get; internal set; }

        //public virtual Tamanho TamanhoDeMaterial { get; internal set; }

        //public virtual Unidade Unidade { get; internal set; }

        public double Quantidade { get; internal set; }

        public double CustoPadrao { get; internal set; }

        IModelo INecessidadeDeMaterial.Modelo => Modelo;

        ITamanhoDeModelo INecessidadeDeMaterial.TamanhoDeModelo => TamanhoDeModelo;

        IMaterial INecessidadeDeMaterial.Material => Material;

        //ICorDeFabricante INecessidadeDeMaterial.Cor => Cor;

        //ITamanho INecessidadeDeMaterial.TamanhoDeMaterial => TamanhoDeMaterial;

        //IUnidade INecessidadeDeMaterial.Unidade => Unidade;

        public string ModeloCodigo { get; internal set; }

        public int MaterialId { get; internal set; }
    }
}
