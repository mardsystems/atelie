using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Materiais
{
    public class MateriaisPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICadastroDeMateriais, MateriaisHttpService>();

            container.Register<IConsultaDeMateriais, MateriaisHttpService>();
        }
    }
}
