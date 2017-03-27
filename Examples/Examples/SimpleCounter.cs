using System;

namespace Examples
{
	internal class SimpleCounter : ICounter
	{
		private int current;

		public int Current
		{
			get
			{
				return current;
			}
		}

		public void Increment()
		{
			current++;
		}
	}
}
