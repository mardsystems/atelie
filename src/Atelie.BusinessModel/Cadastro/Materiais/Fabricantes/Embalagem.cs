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
    }
}
