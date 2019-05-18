namespace Atelie.Cadastro.Modelos.Investimentos
{
    public interface IInvestimento
    {
        int Id { get; }

        TipoDeInvestimento Tipo { get; }

        //string Nome { get; }

        /// <summary>
        /// Gastos com livros, objetos inspiratdores, e ferramentas de desenho/pilotagem.
        /// </summary>
        decimal LivrosEObjetos { get; }

        /// <summary>
        /// Gastos com viagens ligadas a pesquisa/desenvolvimento.
        /// </summary>
        decimal Viagens { get; }

        /// <summary>
        /// Gastos com materiais usados em várias fases do desenvolvimento (desde a pesquisa até a pilotagem).
        /// </summary>
        decimal Materiais { get; }

        /// <summary>
        /// Gastos com mão de obra própria.
        /// </summary>
        decimal MaoDeObra { get; }

        /// <summary>
        /// Gastos com serviços de terceiros.
        /// </summary>
        decimal Terceiros { get; }

        decimal CustoTotal { get; }
    }
}
