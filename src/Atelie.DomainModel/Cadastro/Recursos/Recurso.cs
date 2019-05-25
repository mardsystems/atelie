using Atelie.Comum;

namespace Atelie.Cadastro.Recursos
{
    public class Recurso : PessoaFisica
    {
        public virtual TipoDeRecurso Tipo { get; internal set; }

        public decimal? CustoPadrao { get; internal set; }

        public virtual Cargo Cargo { get; internal set; }

        public virtual Departamento Departamento { get; internal set; }
    }
}
