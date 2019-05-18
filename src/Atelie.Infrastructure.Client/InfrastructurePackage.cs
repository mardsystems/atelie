using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Transactions;

namespace Atelie
{
    public class InfrastructurePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            HttpClient client = new HttpClient();

            var baseAdresse = ConfigurationManager.AppSettings["AtelieBaseAddress"].ToString();

            client.BaseAddress = new Uri(baseAdresse);

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            container.RegisterInstance(client);
        }
    }
}
