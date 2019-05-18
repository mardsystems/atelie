using Atelie.Cadastro.Modelos.Investimentos;
using Atelie.Cadastro.Modelos.Producao;
using System.Collections.Generic;
using System.Linq;

namespace Atelie.Cadastro.Modelos
{
    public class Modelo : IModelo
    {
        public string Codigo { get; internal set; }

        public string Nome { get; internal set; }

        public decimal Preco { get; internal set; }

        public IEnumerable<NecessidadeDeMaterial> MateriaisNecessarios { get; internal set; }

        public ICollection<EtapaDeProducao> EtapasDeProducao { get; internal set; }

        public IEnumerable<AplicacaoDeInvestimento> Investimentos { get; internal set; }

        INecessidadeDeMaterial[] IModelo.MateriaisNecessarios => MateriaisNecessarios.ToArray();

        IEtapaDeProducao[] IModelo.EtapasDeProducao => EtapasDeProducao.ToArray();

        IAplicacaoDeInvestimento[] IModelo.Investimentos => Investimentos.ToArray();

        public Modelo(string codigo)
        {
            Codigo = codigo;

            MateriaisNecessarios = new HashSet<NecessidadeDeMaterial>();

            EtapasDeProducao = new HashSet<EtapaDeProducao>();

            Investimentos = new HashSet<AplicacaoDeInvestimento>();
        }
    }
}
