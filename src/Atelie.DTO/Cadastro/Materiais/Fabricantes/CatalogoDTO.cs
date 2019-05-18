namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class CatalogoDTO : ICatalogo
    {
        public FabricacaoDeComponenteDTO FabricacaoDeComponente { get; set; }

        public string Nome { get; set; }

        public CorDeFabricanteDTO[] Cores { get; set; }

        public DisponibilidadeDeEmbalagemDTO[] Embalagens { get; set; }

        IFabricacaoDeComponente ICatalogo.FabricacaoDeComponente => FabricacaoDeComponente;

        ICorDeFabricante[] ICatalogo.Cores => Cores;

        IDisponibilidadeDeEmbalagem[] ICatalogo.Embalagens => Embalagens;
    }
}
