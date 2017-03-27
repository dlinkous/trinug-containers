using System;
using System.Collections.Generic;

namespace Processor.IO.Memory
{
	public class MemoryRegistry : IRegistry
	{
		private readonly List<Record> registry = new List<Record>();

		public void Save(int id, int hits)
		{
			registry.Add(new Record(id, hits));
		}

		public IEnumerable<Record> RetrieveAll()
		{
			return registry;
		}

		public void Clear()
		{
			registry.Clear();
		}
	}
}
