using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System;

namespace Atelie.Api
{
    public class Startup
    {
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSimpleInjector(services);

            services.AddMvc(options =>
            {
                //options.RespectBrowserAcceptHeader = true;
                //options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                //options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            })
            //.AddXmlSerializerFormatters()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            })
            .AddXmlDataContractSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration.GetConnectionString("Atelie");

            services.AddDbContext<AtelieDbContext>(options =>
            {
                options.UseSqlServer(connectionString, p => p.MigrationsAssembly("Atelie.Migrations"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitializeContainer(app);

            app.UseMvc();
        }

        private void ConfigureSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));

            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);

            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            var package = new InfrastructurePackage();

            container.RegisterMvcControllers(app);

            container.RegisterMvcViewComponents(app);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            container.RegisterPackages(assemblies);

            container.AutoCrossWireAspNetComponents(app);

            //app.UseMiddleware<CustomMiddleware1>();

            container.Verify();
        }
    }
}
