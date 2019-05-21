using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanosComerciaisPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IPlanejamentoComercial, ServicoDePlanejamentoComercial>();

            container.Register<IConsultaDePlanosComerciais, PlanosComerciaisDbService>();

            container.Register<IRepositorioDePlanosComerciais, PlanosComerciaisDbService>();

            //

            //container.RegisterConditional<Autorization, AuthorizationService>(
            //    c => c.Consumer.ImplementationType == typeof(TransactionsAuthorizationService)
            //);
        }
    }
}
