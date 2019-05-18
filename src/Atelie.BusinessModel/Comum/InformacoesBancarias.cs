namespace Atelie.Comum
{
    public interface IInformacoesBancarias
    {
        string NumeroDoBanco { get; }

        string NumeroDaAgencia { get; }

        string NumeroDaConta { get; }

        string NomeDoCorrentista { get; }
    }
}
