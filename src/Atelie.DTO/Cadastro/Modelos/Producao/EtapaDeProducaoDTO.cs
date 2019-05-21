using Atelie.Cadastro.Modelos.Producao.Ferramentas;

namespace Atelie.Cadastro.Modelos.Producao
{
    public class EtapaDeProducaoDTO : IEtapaDeProducao
    {
        public int Id { get; set; }

        public int Ordem { get; set; }

        public string Descricao { get; set; }

        public NecessidadeDeTipoDeRecursoDTO[] TiposDeRecursoNecessarios { get; set; }

        public NecessidadeDeFerramentaDeProducaoDTO[] FerramentasNecessarias { get; set; }

        INecessidadeDeTipoDeRecurso[] IEtapaDeProducao.TiposDeRecursoNecessarios => TiposDeRecursoNecessarios;

        INecessidadeDeFerramentaDeProducao[] IEtapaDeProducao.FerramentasNecessarias => FerramentasNecessarias;
    }
}
