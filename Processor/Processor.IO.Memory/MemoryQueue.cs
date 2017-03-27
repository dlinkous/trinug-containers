using System;
using System.Collections.Generic;

namespace Processor.IO.Memory
{
	public class MemoryQueue : IQueue
	{
		private readonly Queue<int> queue = new Queue<int>();

		public void Enqueue(int id)
		{
			queue.Enqueue(id);
		}

		public int Dequeue()
		{
			return queue.Dequeue();
		}

		public void Clear()
		{
			queue.Clear();
		}
	}
}
