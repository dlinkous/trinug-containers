using System;

namespace Processor.IO
{
	public struct Record
	{
		public int Id { get; private set; }
		public int Hits { get; private set; }

		public Record(int id, int hits)
		{
			Id = id;
			Hits = hits;
		}
	}
}
