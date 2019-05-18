namespace Atelie.Cadastro.Unidades
{
    public interface IConversaoDeUnidade
    {
        IUnidadeDeMedida Unidade { get; }

        IUnidadeDeMedida UnidadeBase { get; }

        double Valor { get; }
    }
}
