using Atelie.Cadastro.Cores;
using Atelie.Comum;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public interface ICorDeFabricante : ICor
    {
        ICatalogo Catalogo { get; }

        /// <summary>
        /// Ex.: A, B, C, D, etc..
        /// </summary>
        string Categoria { get; }

        string Localizacao { get; }

        decimal? CustoPadrao { get; }

        ICorInterna CorDeUsoInterno { get; }
    }
}
