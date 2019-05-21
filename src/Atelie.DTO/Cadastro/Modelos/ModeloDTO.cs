using Atelie.Cadastro.Modelos.Investimentos;
using Atelie.Cadastro.Modelos.Producao;

namespace Atelie.Cadastro.Modelos
{
    public class ModeloDTO : IModelo
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public NecessidadeDeMaterialDTO[] MateriaisNecessarios { get; set; }

        public EtapaDeProducaoDTO[] EtapasDeProducao { get; set; }

        public AplicacaoDeInvestimentoDTO[] Investimentos { get; set; }

        INecessidadeDeMaterial[] IModelo.MateriaisNecessarios => MateriaisNecessarios;

        IEtapaDeProducao[] IModelo.EtapasDeProducao => EtapasDeProducao;

        IAplicacaoDeInvestimento[] IModelo.Investimentos => Investimentos;
    }
}
