﻿using SimpleInjector;
using SimpleInjector.Packaging;

namespace Atelie.Decisoes.Comerciais
{
    public class PlanosComerciaisPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<PlanosComerciaisLocalService>();

            container.Register<PlanosComerciaisHttpService>();
        }
    }
}
