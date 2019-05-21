using Atelie.Cadastro.Recursos;

namespace Atelie.Cadastro.Modelos.Producao
{
    public class NecessidadeDeTipoDeRecursoDTO : INecessidadeDeTipoDeRecurso
    {
        public EtapaDeProducaoDTO Etapa { get; set; }

        public TipoDeRecursoDTO TipoDeRecurso { get; set; }

        public string Tarefa { get; set; }

        public int Quantidade { get; set; }

        public double Tempo { get; set; }

        public decimal? CustoPadrao { get; set; }

        IEtapaDeProducao INecessidadeDeTipoDeRecurso.Etapa => Etapa;

        ITipoDeRecurso INecessidadeDeTipoDeRecurso.TipoDeRecurso => TipoDeRecurso;
    }
}
