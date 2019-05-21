namespace Atelie.Cadastro.Modelos.Investimentos
{
    public class InvestimentoDTO : IInvestimento
    {
        public int Id { get; set; }

        public TipoDeInvestimento Tipo { get; set; }

        public decimal LivrosEObjetos { get; set; }

        public decimal Viagens { get; set; }

        public decimal Materiais { get; set; }

        public decimal MaoDeObra { get; set; }

        public decimal Terceiros { get; set; }

        public decimal CustoTotal { get; set; }
    }
}
