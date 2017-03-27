using System;
using SimpleInjector;

namespace Examples
{
	public class Program
	{
		public static void Main(string[] args)
		{
			TestCleaner();
			TestLogger();
			TestCleanerWithContainer();
			TestCounter();
			Console.ReadKey();
		}

		private static void TestCleaner()
		{
			ICleaner cleaner = new Cleaner(new ConsoleLogger());
			const string input = "Space: the final frontier.";
			var cleaned = cleaner.CleanWhitespace(input);
			//DoStuffWithString(cleaned);
		}

		private static void TestLogger()
		{
			var container = new Container();
			container.Register<ILogger, ConsoleLogger>();
			var logger = container.GetInstance<ILogger>();
			logger.Log("TestLogger");
		}

		private static void TestCleanerWithContainer()
		{
			var container = new Container();
			container.Register<ILogger, ConsoleLogger>();
			container.Register<ICleaner, Cleaner>();
			var cleaner = container.GetInstance<ICleaner>();
			const string input = "Space: the final frontier.";
			var cleaned = cleaner.CleanWhitespace(input);
			//DoStuffWithString(cleaned);
		}

		private static void TestCounter()
		{
			var container = new Container();
			container.Register<ICounter, SimpleCounter>(Lifestyle.Singleton);
			var counter1 = container.GetInstance<ICounter>();
			counter1.Increment();
			var counter2 = container.GetInstance<ICounter>();
			counter2.Increment();
			Console.WriteLine(counter1.Current);
			Console.WriteLine(counter2.Current);
		}
	}
}
