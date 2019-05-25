using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanosComerciaisPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            //container.Register<ServicoDePlanejamentoComercial>();

            container.Register<PlanosComerciaisDbService>();

            container.Register<IRepositorioDePlanosComerciais, PlanosComerciaisDbService>();

            //

            //container.RegisterConditional<Autorization, AuthorizationService>(
            //    c => c.Consumer.ImplementationType == typeof(TransactionsAuthorizationService)
            //);
        }
    }
}
