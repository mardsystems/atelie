namespace Atelie.Cadastro.Materiais.Fabricantes
{
    /// <summary>
    /// Cartela de cores, catálogo de produtos, etc...
    /// </summary>
    public interface ICatalogo
    {
        IFabricacaoDeComponente FabricacaoDeComponente { get; }

        /// <summary>
        /// Ex.: Padrão.
        /// </summary>
        string Nome { get; }

        ICorDeFabricante[] Cores { get; }

        IDisponibilidadeDeEmbalagem[] Embalagens { get; }
    }
}
