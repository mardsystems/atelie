using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public class ComponentesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICadastroDeComponentes, ComponentesHttpService>();

            container.Register<IConsultaDeComponentes, ComponentesHttpService>();
        }
    }
}
