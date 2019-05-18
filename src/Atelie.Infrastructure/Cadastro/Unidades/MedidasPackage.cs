using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Unidades
{
    public class MedidasPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICadastroDeUnidadesDeMedidas, ServicoDeCadastroDeUnidadesDeMedidas>();

            container.Register<IConsultaDeUnidadesDeMedidas, UnidadesDeMedidasDbService>();

            container.Register<RepositorioDeUnidadesDeMedidas, UnidadesDeMedidasDbService>();
        }
    }
}
