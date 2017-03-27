using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Processor.Core;
using Processor.IO;

namespace Processor.WebApplication.Controllers
{
    public class HomeController : Controller
    {
		private readonly IQueue queue;
		private readonly IStore store;
		private readonly IRegistry registry;
		private readonly IProcessor processor;

		public HomeController(IQueue queue, IStore store, IRegistry registry, IProcessor processor)
		{
			this.queue = queue;
			this.store = store;
			this.registry = registry;
			this.processor = processor;
		}

		public ActionResult Index()
        {
			SetupData();
			DemonstrateProcessor();
			var result = registry.RetrieveAll().Select(r => $"{r.Id}: {r.Hits}").ToArray();
			return View(result);
        }

		private void SetupData()
		{
			store.Create(1, "The # character is often used in hashtags, such as the most common hashtag #love.");
			store.Create(2, "#####");
			store.Create(3, "Phone #: 1234567890");
			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);
		}

		private void DemonstrateProcessor()
		{
			processor.Process();
			processor.Process();
			processor.Process();
		}
	}
}