using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Unidades
{
    public class MedidasPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICadastroDeUnidadesDeMedidas, UnidadesDeMedidasHttpService>();

            container.Register<IConsultaDeUnidadesDeMedidas, UnidadesDeMedidasHttpService>();
        }
    }
}
