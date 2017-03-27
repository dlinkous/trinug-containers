using System;
using System.Linq;
using Processor.IO;

namespace Processor.Core.Processors
{
	public class OctothorpeProcessor : IProcessor
	{
		private readonly IQueue queue;
		private readonly IStore store;
		private readonly IRegistry registry;

		public OctothorpeProcessor(IQueue queue, IStore store, IRegistry registry)
		{
			this.queue = queue;
			this.store = store;
			this.registry = registry;
		}

		public void Process()
		{
			var id = queue.Dequeue();
			var body = store.Read(id);
			var hits = body.ToCharArray().Where(c => c == '#').Count();
			registry.Save(id, hits);
		}
	}
}
