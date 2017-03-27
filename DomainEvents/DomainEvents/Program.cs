using System;
using SimpleInjector;
using DomainEvents.Domain;
using DomainEvents.Publishers;

namespace DomainEvents
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var container = new Container();
			container.Register<ILevel1, Level1>();
			container.Register<ILevel2, Level2>();
			container.Register<ILevel3, Level3>();
			container.Register<ILevel4, Level4>();
			container.Register<ILevel5, Level5>();
			container.Register<IPublisher, SimpleInjectorPublisher>();
			container.RegisterCollection(typeof(IHandler<>), new[] { typeof(IHandler<>).Assembly });
			container.Verify();

			var level1 = container.GetInstance<ILevel1>();
			level1.Execute();
			Console.ReadKey();
		}
	}
}
