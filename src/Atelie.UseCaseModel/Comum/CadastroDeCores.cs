namespace Atelie.Comum
{
    public interface ICadastroDeCores
    {

    }

    public interface ISolicitacaoDeCadastroDeCor
    {
        string Codigo { get; }

        string RGB { get; }

        string Nome { get; }

        string Descricao { get; }
    }

    public interface IRespostaDeCadastroDeCor
    {

    }

    public abstract class SolicitacaoDeCadastroDeCor : ISolicitacaoDeCadastroDeCor
    {
        public string Codigo { get; set; }

        public string RGB { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }

    public abstract class RespostaDeCadastroDeCor : IRespostaDeCadastroDeCor
    {

    }
}
