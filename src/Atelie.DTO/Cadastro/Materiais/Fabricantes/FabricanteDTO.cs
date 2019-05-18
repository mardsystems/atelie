namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricanteDTO : IFabricante
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Marca { get; set; }

        public string Site { get; set; }

        public FabricacaoDeComponenteDTO[] ComponentesFabricados { get; set; }

        IFabricacaoDeComponente[] IFabricante.ComponentesFabricados => ComponentesFabricados;
    }
}
