using System;
using System.Collections.Generic;
using io = System.IO;
using System.Linq;

namespace Processor.IO.File
{
	public class FileQueue : IQueue
	{
		private readonly IFileSettings fileSettings;

		public FileQueue(IFileSettings fileSettings)
		{
			this.fileSettings = fileSettings;
		}

		public void Enqueue(int id)
		{
			var ids = GetIds();
			ids.Add(id);
			SetIds(ids);
		}

		public int Dequeue()
		{
			var ids = GetIds();
			var id = ids[0];
			ids.RemoveAt(0);
			SetIds(ids);
			return id;
		}

		public void Clear()
		{
			SetIds(new int[] { }.ToList());
		}

		private List<int> GetIds()
		{
			return io.File.ReadAllText(GetFilePath())
				.Split(',')
				.Where(s => !String.IsNullOrWhiteSpace(s))
				.Select(s => Int32.Parse(s))
				.ToList();
		}

		private void SetIds(List<int> ids)
		{
			io.File.WriteAllText(GetFilePath(), String.Join(",", ids));
		}

		private string GetFilePath()
		{
			return fileSettings.RootPath + "\\Queue.queue";
		}
	}
}
