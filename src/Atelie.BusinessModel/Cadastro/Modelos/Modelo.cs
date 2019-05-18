using Atelie.Cadastro.Modelos.Investimentos;
using Atelie.Cadastro.Modelos.Producao;

namespace Atelie.Cadastro.Modelos
{
    public interface IModelo
    {
        string Codigo { get; }

        string Nome { get; }

        decimal Preco { get; }

        INecessidadeDeMaterial[] MateriaisNecessarios { get; }

        IEtapaDeProducao[] EtapasDeProducao { get; }

        IAplicacaoDeInvestimento[] Investimentos { get; }
    }
}
