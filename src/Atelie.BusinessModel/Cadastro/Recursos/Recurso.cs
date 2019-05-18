using Atelie.Comum;

namespace Atelie.Cadastro.Recursos
{
    public interface IRecurso : IPessoaFisica
    {
        ITipoDeRecurso Tipo { get; }

        decimal? CustoPadrao { get; }

        ICargo Cargo { get; }

        IDepartamento Departamento { get; }
    }
}
