using Atelie.Cadastro.Cores;
using Atelie.Comum;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class CorDeFabricanteDTO : CorDTO, ICorDeFabricante
    {
        public CatalogoDTO Catalogo { get; set; }

        public string Categoria { get; set; }

        public string Localizacao { get; set; }

        public decimal? CustoPadrao { get; set; }

        public CorInternaDTO CorDeUsoInterno { get; set; }

        ICatalogo ICorDeFabricante.Catalogo => Catalogo;

        ICorInterna ICorDeFabricante.CorDeUsoInterno => CorDeUsoInterno;
    }
}
