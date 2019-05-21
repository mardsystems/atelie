using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanosComerciaisPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IPlanejamentoComercial, PlanosComerciaisHttpService>();

            container.Register<IConsultaDePlanosComerciais, PlanosComerciaisHttpService>();
        }
    }
}
