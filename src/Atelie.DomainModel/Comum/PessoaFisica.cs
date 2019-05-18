namespace Atelie.Comum
{
    public abstract class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string CPF { get; internal set; }

        public string Identidade { get; internal set; }
    }
}
