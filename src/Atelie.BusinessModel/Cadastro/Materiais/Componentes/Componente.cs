using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Unidades;
using System;
using System.BusinessModel;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public interface IComponente : IAggregateRoot
    {
        int Id { get; }

        string Nome { get; }

        IComponente ComponentePai { get; }

        [Obsolete]
        IFabricacaoDeComponente[] Fabricantes { get; }

        IUnidadeDeMedida UnidadePadrao { get; }
    }
}
