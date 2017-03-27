using System;
using System.Configuration;
using Processor.Core;
using Processor.Core.Processors;
using Processor.IO;
using Processor.IO.File;
using Processor.IO.Memory;

[assembly: WebActivator.PostApplicationStartMethod(typeof(Processor.WebApplication.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Processor.WebApplication.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
			var useFileSystem = Boolean.Parse(ConfigurationManager.AppSettings["UseFileSystem"]);
			if (useFileSystem)
			{
				container.Register<IQueue, FileQueue>(Lifestyle.Singleton);
				container.Register<IStore, FileStore>(Lifestyle.Singleton);
				container.Register<IRegistry, FileRegistry>(Lifestyle.Singleton);
				container.Register<IFileSettings, ServerMapPathFileSettings>(Lifestyle.Singleton);
			}
			else
			{
				container.Register<IQueue, MemoryQueue>(Lifestyle.Singleton);
				container.Register<IStore, MemoryStore>(Lifestyle.Singleton);
				container.Register<IRegistry, MemoryRegistry>(Lifestyle.Singleton);
			}
			container.Register<IProcessor, OctothorpeProcessor>();
		}
    }
}