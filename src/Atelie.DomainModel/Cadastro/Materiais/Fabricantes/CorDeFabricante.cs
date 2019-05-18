using Atelie.Cadastro.Cores;
using Atelie.Comum;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class CorDeFabricante : Cor, ICorDeFabricante
    {
        public virtual Catalogo Catalogo { get; internal set; }

        public string Categoria { get; internal set; }

        public string Localizacao { get; internal set; }

        public decimal? CustoPadrao { get; internal set; }

        public virtual CorInterna CorDeUsoInterno { get; internal set; }

        ICatalogo ICorDeFabricante.Catalogo => Catalogo;

        ICorInterna ICorDeFabricante.CorDeUsoInterno => CorDeUsoInterno;

        public int FabricanteId { get; internal set; }

        public int ComponenteId { get; internal set; }

        public string CatalogoNome { get; internal set; }

        public string CorDeUsoInternoCodigo { get; internal set; }
    }
}
