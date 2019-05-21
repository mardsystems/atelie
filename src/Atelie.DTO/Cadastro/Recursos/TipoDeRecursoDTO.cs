namespace Atelie.Cadastro.Recursos
{
    public class TipoDeRecursoDTO : ITipoDeRecurso
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Interno { get; set; }

        public decimal? CustoPadrao { get; set; }

        public double? MaximoDeHorasPorDia { get; set; }

        public UnidadeDeCustoDTO UnidadeDeCusto { get; set; }

        IUnidadeDeCusto ITipoDeRecurso.UnidadeDeCusto => UnidadeDeCusto;
    }
}
