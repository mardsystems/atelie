using Atelie.Cadastro.Recursos;

namespace Atelie.Cadastro.Modelos.Producao
{
    public interface INecessidadeDeTipoDeRecurso
    {
        IEtapaDeProducao Etapa { get; }

        ITipoDeRecurso TipoDeRecurso { get; }

        string Tarefa { get; }

        int Quantidade { get; }

        double Tempo { get; }

        decimal? CustoPadrao { get; }
    }
}
