using System;

namespace Processor.IO
{
	public interface IQueue
	{
		void Enqueue(int id);
		int Dequeue();
		void Clear();
	}
}
