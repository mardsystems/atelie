using System.DTO;

namespace Atelie.Comum
{
    public abstract class UnidadeDTO : AggregateRootDTO, IUnidade
    {
        public string Sigla { get; set; }

        public string NomeNoSingular { get; set; }

        public string NomeNoPlural { get; set; }
    }
}
