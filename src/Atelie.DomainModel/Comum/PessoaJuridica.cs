namespace Atelie.Comum
{
    public abstract class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string CNPJ { get; internal set; }

        //public InformacoesBancarias InformacoesBancarias { get; internal set; }

        //IInformacoesBancarias IPessoaJuridica.InformacoesBancarias => InformacoesBancarias;
    }
}
