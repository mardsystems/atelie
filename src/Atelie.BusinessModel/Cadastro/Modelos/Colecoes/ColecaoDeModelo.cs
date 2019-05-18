namespace Atelie.Cadastro.Modelos
{
    public interface IColecaoDeModelo
    {
        int Id { get; }

        string Nome { get; }

        StatusDeColecaoDeModelo Status { get; }

        IModelo[] Modelos { get; }
    }

    public interface IAssociacaoModeloColecao
    {
        IColecaoDeModelo Colecao { get; }

        IModelo Modelo { get; }
    }

    public enum StatusDeColecaoDeModelo
    {
        EmUso,
        ForaDeLinha,
    }
}
