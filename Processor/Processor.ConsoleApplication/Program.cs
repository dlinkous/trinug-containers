using System;
using System.Configuration;
using SimpleInjector;
using Processor.Core;
using Processor.Core.Processors;
using Processor.IO;
using Processor.IO.File;
using Processor.IO.Memory;

namespace Processor.ConsoleApplication
{
	public class Program
	{
		private static Container container;

		public static void Main(string[] args)
		{
			InitializeContainer();
			SetupData();
			DemonstrateProcessor();
			DisplayReport();
			Pause();
		}

		private static void InitializeContainer()
		{
			var useFileSystem = Boolean.Parse(ConfigurationManager.AppSettings["UseFileSystem"]);
			container = new Container();
			if (useFileSystem)
			{
				container.Register<IQueue, FileQueue>(Lifestyle.Singleton);
				container.Register<IStore, FileStore>(Lifestyle.Singleton);
				container.Register<IRegistry, FileRegistry>(Lifestyle.Singleton);
				container.Register<IFileSettings, AssemblyLocationFileSettings>(Lifestyle.Singleton);
			}
			else
			{
				container.Register<IQueue, MemoryQueue>(Lifestyle.Singleton);
				container.Register<IStore, MemoryStore>(Lifestyle.Singleton);
				container.Register<IRegistry, MemoryRegistry>(Lifestyle.Singleton);
			}
			container.Register<IProcessor, OctothorpeProcessor>();
			container.Verify();
		}

		private static void SetupData()
		{
			var store = container.GetInstance<IStore>();
			store.Create(1, "The # character is often used in hashtags, such as the most common hashtag #love.");
			store.Create(2, "#####");
			store.Create(3, "Phone #: 1234567890");
			var queue = container.GetInstance<IQueue>();
			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);
		}

		private static void DemonstrateProcessor()
		{
			var processor = container.GetInstance<IProcessor>();
			processor.Process();
			processor.Process();
			processor.Process();
		}

		private static void DisplayReport()
		{
			var registry = container.GetInstance<IRegistry>();
			var report = registry.RetrieveAll();
			foreach (var item in report)
			{
				Console.WriteLine($"{item.Id}: {item.Hits}");
			}
		}

		private static void Pause()
		{
			Console.ReadKey();
		}
	}
}
