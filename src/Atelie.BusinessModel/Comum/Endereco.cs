namespace Atelie.Comum
{
    public interface IEndereco
    {
        string Logradouro { get; }

        string Numero { get; }

        string Complemento { get; }

        string Bairro { get; }

        string Cidade { get; }

        string UF { get; }

        string CEP { get; }
    }
}
