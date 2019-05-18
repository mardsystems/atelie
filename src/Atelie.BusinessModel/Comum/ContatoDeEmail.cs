namespace Atelie.Comum
{
    public interface IContatoDeEmail
    {
        int Id { get; }

        string Nome { get; }

        bool Principal { get; }

        IEmail Email { get; }
    }
}
