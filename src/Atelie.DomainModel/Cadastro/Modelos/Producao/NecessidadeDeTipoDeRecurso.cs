using Atelie.Cadastro.Recursos;

namespace Atelie.Cadastro.Modelos.Producao
{
    public class NecessidadeDeTipoDeRecurso : INecessidadeDeTipoDeRecurso
    {
        public virtual EtapaDeProducao Etapa { get; internal set; }

        public virtual TipoDeRecurso TipoDeRecurso { get; internal set; }

        public string Tarefa { get; internal set; }

        public int Quantidade { get; internal set; }

        public double Tempo { get; internal set; }

        public decimal? CustoPadrao { get; internal set; }

        IEtapaDeProducao INecessidadeDeTipoDeRecurso.Etapa => Etapa;

        ITipoDeRecurso INecessidadeDeTipoDeRecurso.TipoDeRecurso => TipoDeRecurso;
    }
}
