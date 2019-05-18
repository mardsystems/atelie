using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Materiais
{
    public class MateriaisPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICadastroDeMateriais, ServicoDeCadastroDeMateriais>();

            container.Register<IConsultaDeMateriais, MateriaisDbService>();

            container.Register<IRepositorioDeMateriais, MateriaisDbService>();

            //

            //container.RegisterConditional<Autorization, AuthorizationService>(
            //    c => c.Consumer.ImplementationType == typeof(TransactionsAuthorizationService)
            //);
        }
    }
}
