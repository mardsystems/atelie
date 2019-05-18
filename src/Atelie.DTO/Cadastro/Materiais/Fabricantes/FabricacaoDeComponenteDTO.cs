using Atelie.Cadastro.Materiais.Componentes;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricacaoDeComponenteDTO : IFabricacaoDeComponente
    {
        public FabricanteDTO Fabricante { get; set; }

        public ComponenteDTO Componente { get; set; }

        public CatalogoDTO[] Catalogos { get; set; }

        IFabricante IFabricacaoDeComponente.Fabricante => Fabricante;

        IComponente IFabricacaoDeComponente.Componente => Componente;

        ICatalogo[] IFabricacaoDeComponente.Catalogos => Catalogos;
    }
}
