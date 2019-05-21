using Atelie.Cadastro.Materiais;

namespace Atelie.Cadastro.Modelos.Producao
{
    public class NecessidadeDeMaterialDTO : INecessidadeDeMaterial
    {
        public ModeloDTO Modelo { get; set; }

        public TamanhoDeModeloDTO TamanhoDeModelo { get; set; }

        public MaterialDTO Material { get; set; }

        public double Quantidade { get; set; }

        public double CustoPadrao { get; set; }

        IModelo INecessidadeDeMaterial.Modelo => Modelo;

        ITamanhoDeModelo INecessidadeDeMaterial.TamanhoDeModelo => TamanhoDeModelo;

        IMaterial INecessidadeDeMaterial.Material => Material;
    }
}
