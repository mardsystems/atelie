namespace Atelie.Comum
{
    public interface IPessoaJuridica : IPessoa
    {
        string CNPJ { get; }

        //IInformacoesBancarias InformacoesBancarias { get; }
    }
}
