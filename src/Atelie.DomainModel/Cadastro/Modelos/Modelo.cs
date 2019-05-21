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

        public virtual IEnumerable<NecessidadeDeMaterial> MateriaisNecessarios { get; internal set; }

        public virtual ICollection<EtapaDeProducao> EtapasDeProducao { get; internal set; }

        public virtual IEnumerable<AplicacaoDeInvestimento> Investimentos { get; internal set; }

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

        public Modelo()
        {
            MateriaisNecessarios = new HashSet<NecessidadeDeMaterial>();

            EtapasDeProducao = new HashSet<EtapaDeProducao>();

            Investimentos = new HashSet<AplicacaoDeInvestimento>();
        }
    }
}
