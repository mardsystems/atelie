using System.DTO;
using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Materiais.Fornecedores;

namespace Atelie.Cadastro.Materiais
{
    public class MaterialDTO : AggregateRootDTO, IMaterial
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal? CustoPadrao { get; set; }

        public FabricanteDTO Fabricante { get; set; }

        public ComponenteDTO Componente { get; set; }

        //public CatalogoDTO Catalogo { get; set; }

        //public EmbalagemDTO Embalagem { get; set; }

        public FornecimentoDeMaterialDTO[] Fornecedores { get; set; }

        IFabricante IMaterial.Fabricante => Fabricante;

        IComponente IMaterial.Componente => Componente;

        //ICatalogo IMaterial.Catalogo => Catalogo;

        //IEmbalagem IMaterial.Embalagem => Embalagem;

        //IFornecimentoDeMaterial[] IMaterial.Fornecedores => Fornecedores;
    }
}
