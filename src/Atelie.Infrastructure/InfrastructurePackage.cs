using SimpleInjector;
using SimpleInjector.Packaging;
using System.Transactions;

namespace Atelie
{
    public class InfrastructurePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IUnitOfWork, TransactionScopeManager>();

            //container.Register<AtelieDbContext>(Lifestyle.Singleton);
        }
    }
}
