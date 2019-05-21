using Atelie.Cadastro.Unidades;
using Atelie.Comum;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    /// <summary>
    /// DisponibilidadeDeUnidadeDeFabricacao.
    /// </summary>
    public interface IEmbalagem
    {
        IUnidade Unidade { get; }

        double Valor { get; }

        IUnidade UnidadeBase { get; }

        ///// <summary>
        ///// Ex.: Pacote.
        ///// </summary>
        //string Nome { get; }

        /////// <summary>
        /////// Ex.: 10.
        /////// </summary>
        ////double Quantidade { get; }

        /////// <summary>
        /////// Ex.: Cones.
        /////// </summary>
        ////IUnidade Unidade { get; }

        ///// <summary>
        ///// Ex.: 10cn (2000J).
        ///// </summary>
        //ITamanho Tamanho { get; }
    }
}
