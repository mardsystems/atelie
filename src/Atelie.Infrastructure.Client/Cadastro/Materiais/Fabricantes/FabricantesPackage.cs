using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Materiais.Fabricantes
{
    public class FabricantesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICadastroDeFabricantes, FabricantesHttpService>();

            container.Register<IConsultaDeFabricantes, FabricantesHttpService>();

            //

            container.Register<ICadastroDeFabricacoesDeComponentes, FabricacoesDeComponentesHttpService>();

            container.Register<IConsultaDeFabricacoesDeComponentes, FabricacoesDeComponentesHttpService>();
        }
    }
}
