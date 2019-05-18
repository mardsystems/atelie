namespace Atelie.Comum
{
    public abstract class CorDTO : ICor
    {
        public string Codigo { get; set; }

        public string RGB { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
