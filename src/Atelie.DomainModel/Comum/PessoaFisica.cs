namespace Atelie.Comum
{
    public abstract class PessoaFisica : Pessoa
    {
        public string CPF { get; internal set; }

        public string Identidade { get; internal set; }
    }
}
