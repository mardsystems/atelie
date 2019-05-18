using Atelie.Cadastro.Materiais.Componentes;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public interface IFabricacaoDeComponente
    {
        IFabricante Fabricante { get; }

        IComponente Componente { get; }

        ICatalogo[] Catalogos { get; }
    }
}
