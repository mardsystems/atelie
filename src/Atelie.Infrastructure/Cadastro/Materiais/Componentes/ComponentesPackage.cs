using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Cadastro.Materiais.Componentes
{
    public class ComponentesPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICadastroDeComponentes, ServicoDeCadastroDeComponentes>();

            container.Register<IConsultaDeComponentes, ComponentesDbService>();

            container.Register<IRepositorioDeComponentes, ComponentesDbService>();
        }
    }
}
