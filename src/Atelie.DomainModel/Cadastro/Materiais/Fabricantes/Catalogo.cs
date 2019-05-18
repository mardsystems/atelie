using System.Collections.Generic;
using System.Linq;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class Catalogo : ICatalogo
    {
        public virtual FabricacaoDeComponente FabricacaoDeComponente { get; internal set; }

        public string Nome { get; internal set; }

        public string Site { get; internal set; }

        public virtual ICollection<CorDeFabricante> Cores { get; internal set; }

        public virtual ICollection<DisponibilidadeDeEmbalagem> Embalagens { get; internal set; }

        IFabricacaoDeComponente ICatalogo.FabricacaoDeComponente => FabricacaoDeComponente;

        ICorDeFabricante[] ICatalogo.Cores => Cores.ToArray();

        IDisponibilidadeDeEmbalagem[] ICatalogo.Embalagens => Embalagens.ToArray();

        public int FabricanteId { get; internal set; }

        public int ComponenteId { get; internal set; }

        public Catalogo()
        {
            Cores = new HashSet<CorDeFabricante>();

            Embalagens = new HashSet<DisponibilidadeDeEmbalagem>();
        }
    }
}
