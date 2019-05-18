using Atelie.Cadastro.Recursos;

namespace Atelie.Operacoes.Producao
{
    public class AlocacaoDeRecurso : IAlocacaoDeRecurso
    {
        public virtual Recurso Recurso { get; internal set; }

        public decimal Custo { get; internal set; }

        IRecurso IAlocacaoDeRecurso.Recurso => Recurso;
    }
}