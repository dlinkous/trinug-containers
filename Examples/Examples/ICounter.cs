using System;

namespace Examples
{
	internal interface ICounter
	{
		void Increment();
		int Current { get; }
	}
}
