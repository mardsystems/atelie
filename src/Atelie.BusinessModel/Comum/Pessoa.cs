namespace Atelie.Comum
{
    public interface IPessoa
    {
        int Id { get; }

        string Nome { get; }

        //IEndereco Endereco { get; }

        IContatoDeTelefone[] ContatosDeTelefone { get; }

        IContatoDeEmail[] ContatosDeEmail { get; }
    }
}
