namespace Atelie.Comum
{
    public interface IPessoaFisica : IPessoa
    {
        string CPF { get; }

        string Identidade { get; }
    }
}
