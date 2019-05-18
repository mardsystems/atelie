using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricantesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICadastroDeFabricantes, ServicoDeCadastroDeFabricantes>();

            container.Register<IConsultaDeFabricantes, FabricantesDbService>();

            container.Register<IRepositorioDeFabricantes, FabricantesDbService>();

            //

            container.Register<ICadastroDeFabricacoesDeComponentes, ServicoDeCadastroDeFabricacoesDeComponentes>();

            container.Register<IConsultaDeFabricacoesDeComponentes, FabricacoesDeComponentesDbService>();

            container.Register<IRepositorioDeFabricacoesDeComponentes, FabricacoesDeComponentesDbService>();
        }
    }
}
