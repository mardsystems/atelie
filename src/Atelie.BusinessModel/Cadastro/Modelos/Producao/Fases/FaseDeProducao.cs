using Atelie.Cadastro.Modelos.Producao.Ferramentas;

namespace Atelie.Cadastro.Modelos.Producao.Fases
{
    public interface IFaseDeProducao
    {
        int Id { get; }

        string Nome { get; }

        IDisponibilidadeDeFerramentaDeProducao[] FerramentasDisponiveis { get; }

        IDisponibilidadeDeTipoDeRecurso[] TiposDeRecusosDisponiveis { get; }
    }
}
