using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class Fabricante
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        public string Marca { get; internal set; }

        public string Site { get; internal set; }

        public Fabricante(
            int id,
            string nome,
            string marca,
            string site
        )
        {
            Id = id;

            Nome = nome;

            Marca = marca;

            Site = site;

            #region Infraestrutura

            ComponentesFabricados = new List<FabricacaoDeComponente>();

            #endregion
        }

        #region Infraestrutura

        public Fabricante()
        {
            ComponentesFabricados = new HashSet<FabricacaoDeComponente>();
        }

        public virtual IEnumerable<FabricacaoDeComponente> ComponentesFabricados { get; internal set; }

        #endregion
    }

    public interface IRepositorioDeFabricantes
    {
        Task<Fabricante> ObtemFabricante(int id);

        Task Add(Fabricante material);

        Task Update(Fabricante material);

        Task Remove(Fabricante material);
    }
}
