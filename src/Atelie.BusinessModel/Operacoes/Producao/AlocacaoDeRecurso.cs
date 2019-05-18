using Atelie.Cadastro.Recursos;

namespace Atelie.Operacoes.Producao
{
    public interface IAlocacaoDeRecurso
    {
        IRecurso Recurso { get; }

        decimal Custo { get; }
    }
}
