using Atelie.Comum;

namespace Atelie.Cadastro.Unidades
{
    public interface ITamanho
    {
        IUnidade Unidade { get; }

        /// <summary>
        /// Ex.: 2000, 1, 1.
        /// </summary>
        double Quantidade { get; }

        /// <summary>
        /// Ex.: Jardas, Cone, Unidade.
        /// </summary>
        //IUnidade Unidade { get; }
    }
}
