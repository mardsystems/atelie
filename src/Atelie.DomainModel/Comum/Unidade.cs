namespace Atelie.Comum
{
    public abstract class Unidade
    {
        public string Sigla { get; internal set; }

        public string NomeNoSingular { get; internal set; }

        public string NomeNoPlural { get; internal set; }

        protected Unidade(
            string sigla,
            string nomeNoSingular,
            string nomeNoPlural
        )
        {
            Sigla = sigla;

            NomeNoSingular = nomeNoSingular;

            NomeNoPlural = nomeNoPlural;
        }

        protected Unidade()
        {

        }
    }
}
