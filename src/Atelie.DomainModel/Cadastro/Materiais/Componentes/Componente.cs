using Atelie.Cadastro.Materiais.Fabricantes;
using Atelie.Cadastro.Unidades;
using System.Collections.Generic;
using System.DomainModel;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public class Componente : AggregateRoot, IComponente
    {
        public int Id { get; internal set; }

        public string Nome { get; internal set; }

        public virtual Componente ComponentePai { get; internal set; }

        public virtual UnidadeDeMedida UnidadePadrao { get; internal set; }

        public Componente(
            int id,
            string nome,
            Componente componentePai,
            UnidadeDeMedida unidadePadrao
        )
        {
            Id = id;

            Nome = nome;

            ComponentePai = componentePai;

            UnidadePadrao = unidadePadrao;

            UnidadePadraoSigla = unidadePadrao.Sigla;

            #region Infraestrutura

            if (componentePai == null)
            {
                ComponentePaiId = null;
            }
            else
            {
                ComponentePaiId = componentePai.Id;
            }

            Fabricantes = new HashSet<FabricacaoDeComponente>();

            #endregion
        }

        #region IComponente

        IComponente IComponente.ComponentePai => ComponentePai;

        IUnidadeDeMedida IComponente.UnidadePadrao => UnidadePadrao;

        IFabricacaoDeComponente[] IComponente.Fabricantes => Fabricantes.ToArray();

        #endregion

        #region Infraestrutura

        public Componente()
        {
            Fabricantes = new HashSet<FabricacaoDeComponente>();
        }

        public int? ComponentePaiId { get; internal set; }

        public string UnidadePadraoSigla { get; internal set; }

        public virtual IEnumerable<FabricacaoDeComponente> Fabricantes { get; internal set; }

        #endregion
    }

    public interface IRepositorioDeComponentes
    {
        Task<Componente> ObtemComponente(int id);

        Task Add(Componente material);

        Task Update(Componente material);

        Task Remove(Componente material);
    }
}
