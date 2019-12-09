using Microsoft.Practices.Unity;
using System.Web.Http;
using Raci.B2C.Bicycle.Service.DataAccess;
using Unity.WebApi;

namespace Raci.B2C.Bicycle.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterInstance<IContextFactory>(new DefaultContextFactory("databaseConnectionString"));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}