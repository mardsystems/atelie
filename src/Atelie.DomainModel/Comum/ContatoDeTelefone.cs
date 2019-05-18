namespace Atelie.Comum
{
    public class ContatoDeTelefone : IContatoDeTelefone
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        public bool Principal { get; internal set; }

        public virtual Telefone Telefone { get; internal set; }

        ITelefone IContatoDeTelefone.Telefone => Telefone;
    }
}
