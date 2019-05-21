using Atelie.Cadastro.Unidades;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    /// <summary>
    /// Cartela de cores, catálogo de produtos, linha de produto, etc...
    /// </summary>
    public interface ICatalogo
    {
        IFabricacaoDeComponente FabricacaoDeComponente { get; }

        /// <summary>
        /// Ex.: Padrão.
        /// </summary>
        string Nome { get; }

        ICorDeFabricante[] Cores { get; }

        //IUnidadeDeFabricacao[] Tamanhos { get; }

        IDisponibilidadeDeEmbalagem[] Embalagens { get; }

        //IEmbalagem[] Embalagens { get; }
    }
}
