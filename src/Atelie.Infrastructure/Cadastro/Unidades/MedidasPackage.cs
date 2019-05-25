using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Unidades
{
    public class MedidasPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            //container.Register<ServicoDeCadastroDeUnidadesDeMedidas>();

            container.Register<UnidadesDeMedidasDbService>();

            container.Register<RepositorioDeUnidadesDeMedidas, UnidadesDeMedidasDbService>();
        }
    }
}
