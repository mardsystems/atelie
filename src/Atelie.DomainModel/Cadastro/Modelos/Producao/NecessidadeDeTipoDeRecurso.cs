using Atelie.Cadastro.Recursos;

namespace Atelie.Cadastro.Modelos.Producao
{
    public class NecessidadeDeTipoDeRecurso
    {
        public virtual EtapaDeProducao Etapa { get; internal set; }

        public virtual TipoDeRecurso TipoDeRecurso { get; internal set; }

        public string Tarefa { get; internal set; }

        public int Quantidade { get; internal set; }

        public double Tempo { get; internal set; }

        public decimal? CustoPadrao { get; internal set; }

        public int EtapaId { get; internal set; }

        public int TipoDeRecursoId { get; internal set; }
    }
}
