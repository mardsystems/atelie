namespace Atelie.Cadastro.Modelos.Investimentos
{
    public class Investimento : IInvestimento
    {
        public int Id { get; internal set; }

        public TipoDeInvestimento Tipo { get; internal set; }

        public decimal LivrosEObjetos { get; internal set; }

        public decimal Viagens { get; internal set; }

        public decimal Materiais { get; internal set; }

        public decimal MaoDeObra { get; internal set; }

        public decimal Terceiros { get; internal set; }

        public decimal CustoTotal { get; internal set; }
    }
}
