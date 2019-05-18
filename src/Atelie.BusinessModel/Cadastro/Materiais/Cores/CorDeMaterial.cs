using Atelie.Cadastro.Cores;
using Atelie.Comum;

namespace Atelie.Cadastro.Materiais.Cores
{
    public interface ICorDeMaterial : ICor
    {
        ICartelaDeCores Cartela { get; }

        /// <summary>
        /// Ex.: A, B, C, D, etc..
        /// </summary>
        string Categoria { get; }

        string Localizacao { get; }

        decimal? CustoPadrao { get; }

        ICorInterna CorDeUsoInterno { get; }
    }
}
