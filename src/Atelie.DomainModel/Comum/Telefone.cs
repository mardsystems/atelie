namespace Atelie.Comum
{
    public class Telefone : ITelefone
    {
        public string DDD { get; internal set; }

        public string Numero { get; internal set; }

        public TipoDeTelefone Tipo { get; internal set; }
    }
}
