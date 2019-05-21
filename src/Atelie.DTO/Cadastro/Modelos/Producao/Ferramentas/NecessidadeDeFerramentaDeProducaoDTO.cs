namespace Atelie.Cadastro.Modelos.Producao.Ferramentas
{
    public class NecessidadeDeFerramentaDeProducaoDTO : INecessidadeDeFerramentaDeProducao
    {
        public EtapaDeProducaoDTO EtapaDeProducao { get; set; }

        public FerramentaDeProducaoDTO Ferramenta { get; set; }

        public int Quantidade { get; set; }

        IEtapaDeProducao INecessidadeDeFerramentaDeProducao.EtapaDeProducao => EtapaDeProducao;

        IFerramentaDeProducao INecessidadeDeFerramentaDeProducao.Ferramenta => Ferramenta;
    }
}
