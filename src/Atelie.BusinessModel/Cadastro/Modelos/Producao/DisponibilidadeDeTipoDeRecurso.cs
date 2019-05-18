using Atelie.Cadastro.Modelos.Producao.Fases;
using Atelie.Cadastro.Recursos;

namespace Atelie.Cadastro.Modelos.Producao
{
    public interface IDisponibilidadeDeTipoDeRecurso
    {
        IFaseDeProducao Fase { get; }

        ITipoDeRecurso TipoDeRecurso { get; }
    }
}
