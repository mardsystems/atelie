using Atelie.Comum;
using System.Threading.Tasks;

namespace Atelie.Cadastro.Unidades
{
    public class UnidadeDeMedida : Unidade
    {
        //public ConversaoDeUnidade[] De { get; internal set; }

        //public ConversaoDeUnidade[] Para { get; internal set; }

        public UnidadeDeMedida(
            string sigla,
            string nomeNoSingular,
            string nomeNoPlural
        )
        : base(
            sigla,
            nomeNoSingular,
            nomeNoPlural
        )
        {

        }

        public UnidadeDeMedida()
        {

        }
    }

    public interface RepositorioDeUnidadesDeMedidas
    {
        Task<UnidadeDeMedida> ObtemUnidadeDeMedida(string sigla);

        Task Add(UnidadeDeMedida unidadeDeMedida);

        Task Update(UnidadeDeMedida unidadeDeMedida);

        Task Remove(UnidadeDeMedida unidadeDeMedida);
    }
}
