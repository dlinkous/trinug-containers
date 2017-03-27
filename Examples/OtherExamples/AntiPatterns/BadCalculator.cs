using System;
using SimpleInjector;

namespace OtherExamples.AntiPatterns
{
	internal class BadCalculator
	{
		private readonly Container container;

		internal BadCalculator(Container container)
		{
			this.container = container;
		}

		internal void Calculate()
		{
			var dependency = container.GetInstance<IDependency>();
			dependency.DoStuff();
		}
	}
}
