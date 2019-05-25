namespace Atelie.Cadastro.Modelos.Producao.Ferramentas
{
    public class NecessidadeDeFerramentaDeProducao
    {
        public virtual EtapaDeProducao EtapaDeProducao { get; internal set; }

        public virtual FerramentaDeProducao Ferramenta { get; internal set; }

        public int Quantidade { get; internal set; }

        public int EtapaDeProducaoId { get; internal set; }

        public int FerramentaId { get; internal set; }
    }
}
