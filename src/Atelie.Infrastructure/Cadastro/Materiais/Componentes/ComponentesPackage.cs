using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public class ComponentesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            //container.Register<ServicoDeCadastroDeComponentes>();

            container.Register<ComponentesDbService>();

            container.Register<IRepositorioDeComponentes, ComponentesDbService>();
        }
    }
}
