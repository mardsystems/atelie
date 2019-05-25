using Atelie.Cadastro.Materiais.Componentes;
using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Materiais.Fornecedores;
using Atelie.Cadastro.Unidades;
using System.Collections.Generic;
using System.DomainModel;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais
{
    public class Material : AggregateRoot
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        public string Descricao { get; internal set; }

        public decimal? CustoPadrao { get; internal set; }

        public virtual Fabricante Fabricante { get; internal set; }

        public virtual Componente Componente { get; internal set; }

        public string Cor { get; internal set; }

        public double Tamanho { get; internal set; }

        public UnidadeDeMedida Unidade { get; internal set; }

        //public Catalogo Catalogo { get; internal set; }

        //public Embalagem Embalagem { get; internal set; }

        public IEnumerable<FornecimentoDeMaterial> Fornecedores { get; internal set; }

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

            Fornecedores = new HashSet<FornecimentoDeMaterial>();

            UnidadeSigla = Unidade.Sigla;

            #endregion
        }

        #region Infraestrutura

        public Material()
        {
            Fornecedores = new HashSet<FornecimentoDeMaterial>();
        }

        public int FabricanteId { get; internal set; }

        public int ComponenteId { get; internal set; }

        public string UnidadeSigla { get; internal set; }

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
