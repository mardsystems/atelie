using Atelie.Cadastro.Modelos.Producao.Ferramentas;
using System.Collections.Generic;
using System.Linq;

namespace Atelie.Cadastro.Modelos.Producao
{
    public class EtapaDeProducao : IEtapaDeProducao
    {
        public int Id { get; internal set; }

        public int Ordem { get; internal set; }

        public string Descricao { get; internal set; }

        public virtual ICollection<NecessidadeDeTipoDeRecurso> TiposDeRecursoNecessarios { get; internal set; }

        public virtual ICollection<NecessidadeDeFerramentaDeProducao> FerramentasNecessarias { get; internal set; }

        INecessidadeDeTipoDeRecurso[] IEtapaDeProducao.TiposDeRecursoNecessarios => TiposDeRecursoNecessarios.ToArray();

        INecessidadeDeFerramentaDeProducao[] IEtapaDeProducao.FerramentasNecessarias => FerramentasNecessarias.ToArray();

        public EtapaDeProducao()
        {
            TiposDeRecursoNecessarios = new HashSet<NecessidadeDeTipoDeRecurso>();

            FerramentasNecessarias = new HashSet<NecessidadeDeFerramentaDeProducao>();
        }
    }
}
