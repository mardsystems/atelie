using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using System.DomainModel;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais
{
    public class Material : AggregateRoot, IMaterial
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        public string Descricao { get; internal set; }

        public decimal? CustoPadrao { get; internal set; }

        public virtual Fabricante Fabricante { get; internal set; }

        public virtual Componente Componente { get; internal set; }

        //public Catalogo Catalogo { get; internal set; }

        //public Embalagem Embalagem { get; internal set; }

        //public IEnumerable<FornecimentoDeMaterial> Fornecedores { get; internal set; }

        public Material(
            int id,
            string nome,
            string descricao,
            decimal? custoPadrao,
            Fabricante fabricante,
            Componente componente
            )
        {
            Id = id;

            Nome = nome;

            Descricao = descricao;

            CustoPadrao = custoPadrao;

            Fabricante = fabricante;

            Componente = componente;

            #region Infraestrutura

            FabricanteId = Fabricante.Id;

            ComponenteId = Componente.Id;

            #endregion
        }

        #region IMaterial

        IFabricante IMaterial.Fabricante => Fabricante;

        IComponente IMaterial.Componente => Componente;

        //ICatalogo IMaterial.Catalogo => Catalogo;

        //IEmbalagem IMaterial.Embalagem => Embalagem;

        //IFornecimentoDeMaterial[] IMaterial.Fornecedores => Fornecedores.ToArray();

        #endregion

        #region Infraestrutura

        public Material()
        {

        }

        public int FabricanteId { get; internal set; }

        public int ComponenteId { get; internal set; }

        #endregion
    }

    public interface IRepositorioDeMateriais
    {
        Task<Material> ObtemMaterial(int id);

        Task Add(Material material);

        Task Update(Material material);

        Task Remove(Material material);
    }
}
