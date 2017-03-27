using System;

namespace OtherExamples.AntiPatterns
{
	internal class GoodCalculator
	{
		private readonly IDependency dependency;

		internal GoodCalculator(IDependency dependency)
		{
			this.dependency = dependency;
		}

		internal void Calculate()
		{
			dependency.DoStuff();
		}
	}
}
