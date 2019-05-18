namespace Atelie.Comum
{
    public class Endereco : IEndereco
    {
        public string Logradouro { get; internal set; }

        public string Numero { get; internal set; }

        public string Complemento { get; internal set; }

        public string Bairro { get; internal set; }

        public string Cidade { get; internal set; }

        public string UF { get; internal set; }

        public string CEP { get; internal set; }
    }
}
