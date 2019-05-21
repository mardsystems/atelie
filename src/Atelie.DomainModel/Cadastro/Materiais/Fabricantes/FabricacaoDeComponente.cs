using Atelie.Cadastro.Materiais.Componentes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricacaoDeComponente : IFabricacaoDeComponente
    {
        public virtual Fabricante Fabricante { get; internal set; }

        public virtual Componente Componente { get; internal set; }

        //public virtual ICollection<Catalogo> Catalogos { get; internal set; }

        public FabricacaoDeComponente(
            Fabricante fabricante,
            Componente componente
        )
        {
            Fabricante = fabricante;

            Componente = componente;

            //Catalogos = new HashSet<Catalogo>();

            #region Infraestrutura

            FabricanteId = fabricante.Id;

            ComponenteId = componente.Id;

            #endregion
        }

        #region IFabricacaoDeComponente

        IFabricante IFabricacaoDeComponente.Fabricante => Fabricante;

        IComponente IFabricacaoDeComponente.Componente => Componente;

        //ICatalogo[] IFabricacaoDeComponente.Catalogos => Catalogos.ToArray();

        #endregion

        #region Infraestrutura

        public FabricacaoDeComponente()
        {
            //Catalogos = new HashSet<Catalogo>();
        }

        public int FabricanteId { get; internal set; }

        public int ComponenteId { get; internal set; }

        #endregion
    }

    public interface IRepositorioDeFabricacoesDeComponentes
    {
        Task<FabricacaoDeComponente> ObtemFabricacaoDeComponente(int fabricanteId, int componenteId);

        Task Add(FabricacaoDeComponente material);

        Task Update(FabricacaoDeComponente material);

        Task Remove(FabricacaoDeComponente material);
    }
}
