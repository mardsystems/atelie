namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public interface IFabricante
    {
        int Id { get; }

        string Nome { get; }

        string Marca { get; }

        string Site { get; }

        IFabricacaoDeComponente[] ComponentesFabricados { get; }
    }
}
