namespace Atelie.Cadastro.Modelos.Producao.Ferramentas
{
    public interface INecessidadeDeFerramentaDeProducao
    {
        IEtapaDeProducao EtapaDeProducao { get; }

        IFerramentaDeProducao Ferramenta { get; }

        int Quantidade { get; }
    }
}
