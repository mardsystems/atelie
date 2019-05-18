namespace Atelie.Comum
{
    public interface IContatoDeTelefone
    {
        int Id { get; }

        string Nome { get; }

        bool Principal { get; }

        ITelefone Telefone { get; }
    }
}
