using System.Threading.Tasks;

namespace Atelie.Cadastro.Materiais
{
    public interface ICadastroDeMateriais
    {
        Task<IRespostaDeCadastroDeMaterial> CadastraMaterial(ISolicitacaoDeCadastroDeMaterial solicitacao);

        Task<IRespostaDeCadastroDeMaterial> AtualizaMaterial(int materialId, ISolicitacaoDeCadastroDeMaterial solicitacao);

        Task ExcluiMaterial(int materialId);
    }

    public interface ISolicitacaoDeCadastroDeMaterial
    {
        int Id { get; }

        string Nome { get; }

        decimal? CustoPadrao { get; }

        string Descricao { get; }

        int ComponenteId { get; }

        int FabricanteId { get; }
    }

    public interface IRespostaDeCadastroDeMaterial
    {
        int Id { get; }
    }

    public class SolicitacaoDeCadastroDeMaterial : ISolicitacaoDeCadastroDeMaterial
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal? CustoPadrao { get; set; }

        public string Descricao { get; set; }

        public int ComponenteId { get; set; }

        public int FabricanteId { get; set; }
    }

    public class RespostaDeCadastroDeMaterial : IRespostaDeCadastroDeMaterial
    {
        public int Id { get; internal set; }
    }
}
