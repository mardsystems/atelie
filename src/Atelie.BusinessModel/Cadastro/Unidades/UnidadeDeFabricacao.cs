using Atelie.Comum;

namespace Atelie.Cadastro.Unidades
{
    public interface IUnidadeDeFabricacao : IUnidade
    {
        //ITamanho Tamanho { get; }

        ///// <summary>
        ///// Ex.: 2000J, 1un.
        ///// </summary>
        //string Descricao { get; }


        //IPeriodoDeUnidadeDeFabricacao PeriodoDeUtilizacao { get; }
    }

    public interface IUnidadeUnidimencional : IUnidadeDeFabricacao
    {
        ITamanho Largura { get; }
    }

    public interface IUnidadeBidimensional : IUnidadeUnidimencional
    {
        ITamanho Altura { get; }
    }

    public interface IUnidadeTridimensional : IUnidadeBidimensional
    {
        ITamanho Comprimento { get; }
    }
}
