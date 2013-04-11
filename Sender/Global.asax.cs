using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus.Example.Sender.App_Start;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace NServiceBus.Example.Sender
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ObjectFactory.Initialize(x => x.Scan(scan =>
                                                     {
                                                         scan.AssembliesFromApplicationBaseDirectory(i => i.FullName.StartsWith("NServiceBus.Example"));
                                                         scan.WithDefaultConventions();
                                                     }));
                                                    
            NServiceBusBootstrapper.Bootstrap();
        }
    }   

    public static class NServiceBusBootstrapper
    {
        public static void Bootstrap()
        {
            Configure.With()
                     .Log4Net()
                     .StructureMapBuilder(ObjectFactory.Container)
                     .XmlSerializer()
                     .MsmqTransport()
                     .UnicastBus()
                     .SendOnly();
        }
    }
}