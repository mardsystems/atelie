namespace Atelie.Cadastro.Recursos
{
    public class TipoDeRecurso
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        public bool Interno { get; internal set; }

        public decimal? CustoPadrao { get; internal set; }

        public double? MaximoDeHorasPorDia { get; internal set; }

        public virtual UnidadeDeCusto UnidadeDeCusto { get; internal set; }
    }
}
