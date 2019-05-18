using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using System.BusinessModel;

namespace Atelie.Cadastro.Materiais
{
    public interface IMaterial : IAggregateRoot
    {
        int Id { get; }

        string Nome { get; }

        string Descricao { get; }

        decimal? CustoPadrao { get; }

        IFabricante Fabricante { get; }

        IComponente Componente { get; }

        //ICatalogo Catalogo { get; }

        /// <summary>
        /// Ex.: Caixa de 2000 jardas - CX(2000J).
        /// </summary>
        //IEmbalagem Embalagem { get; }

        //IFornecimentoDeMaterial[] Fornecedores { get; }
    }
}
