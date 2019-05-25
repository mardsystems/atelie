using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricantesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            //container.Register<ServicoDeCadastroDeFabricantes>();

            container.Register<FabricantesDbService>();

            container.Register<IRepositorioDeFabricantes, FabricantesDbService>();

            //

            //container.Register<ServicoDeCadastroDeFabricacoesDeComponentes>();

            container.Register<FabricacoesDeComponentesDbService>();

            container.Register<IRepositorioDeFabricacoesDeComponentes, FabricacoesDeComponentesDbService>();
        }
    }
}
