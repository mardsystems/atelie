namespace Atelie.Cadastro.Modelos.Producao.Ferramentas
{
    public class NecessidadeDeFerramentaDeProducao : INecessidadeDeFerramentaDeProducao
    {
        public virtual EtapaDeProducao EtapaDeProducao { get; internal set; }

        public virtual FerramentaDeProducao Ferramenta { get; internal set; }

        public int Quantidade { get; internal set; }

        IEtapaDeProducao INecessidadeDeFerramentaDeProducao.EtapaDeProducao => EtapaDeProducao;

        IFerramentaDeProducao INecessidadeDeFerramentaDeProducao.Ferramenta => Ferramenta;
    }
}
