using System.Collections.Generic;
using System.Linq;

namespace Atelie.Comum
{
    public abstract class Pessoa : IPessoa
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        //public virtual Endereco Endereco { get; internal set; }

        public virtual ICollection<ContatoDeTelefone> ContatosDeTelefone { get; internal set; }

        public virtual ICollection<ContatoDeEmail> ContatosDeEmail { get; internal set; }

        //IEndereco IPessoa.Endereco => Endereco;

        IContatoDeTelefone[] IPessoa.ContatosDeTelefone => ContatosDeTelefone.ToArray();

        IContatoDeEmail[] IPessoa.ContatosDeEmail => ContatosDeEmail.ToArray();

        protected Pessoa()
        {
            ContatosDeTelefone = new HashSet<ContatoDeTelefone>();

            ContatosDeEmail = new HashSet<ContatoDeEmail>();
        }
    }
}
