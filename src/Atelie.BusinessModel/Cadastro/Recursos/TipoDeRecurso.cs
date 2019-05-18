namespace Atelie.Cadastro.Recursos
{
    public interface ITipoDeRecurso
    {
        int Id { get; }

        string Nome { get; }

        bool Interno { get; }

        decimal? CustoPadrao { get; }

        double? MaximoDeHorasPorDia { get; }

        IUnidadeDeCusto UnidadeDeCusto { get; }
    }
}
