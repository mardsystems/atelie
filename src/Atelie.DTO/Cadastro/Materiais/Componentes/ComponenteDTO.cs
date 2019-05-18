using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Unidades;
using System.DTO;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public class ComponenteDTO : AggregateRootDTO, IComponente
    {
        public string Nome { get; set; }

        public FabricacaoDeComponenteDTO[] Fabricantes { get; set; }

        IFabricacaoDeComponente[] IComponente.Fabricantes => Fabricantes;

        public int Id { get; set; }

        public ComponenteDTO ComponentePai { get; set; }

        IComponente IComponente.ComponentePai => ComponentePai;

        public UnidadeDeMedidaDTO UnidadePadrao { get; set; }

        IUnidadeDeMedida IComponente.UnidadePadrao => UnidadePadrao;
    }
}
