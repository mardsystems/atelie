using Atelie.Cadastro.Modelos.Producao.Fases;

namespace Atelie.Cadastro.Modelos.Producao.Ferramentas
{
    public interface IDisponibilidadeDeFerramentaDeProducao
    {
        IFaseDeProducao Fase { get; }

        IFerramentaDeProducao Ferramenta { get; }
    }
}
