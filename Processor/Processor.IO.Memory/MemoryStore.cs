using System;
using System.Collections.Generic;

namespace Processor.IO.Memory
{
	public class MemoryStore : IStore
	{
		private readonly Dictionary<int, string> store = new Dictionary<int, string>();

		public void Create(int id, string body)
		{
			store.Add(id, body);
		}

		public string Read(int id)
		{
			return store[id];
		}

		public void Clear()
		{
			store.Clear();
		}
	}
}
