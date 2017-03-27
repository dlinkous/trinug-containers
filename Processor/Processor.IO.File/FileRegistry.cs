using System;
using System.Collections.Generic;
using io = System.IO;
using System.Linq;

namespace Processor.IO.File
{
	public class FileRegistry : IRegistry
	{
		private readonly IFileSettings fileSettings;

		public FileRegistry(IFileSettings fileSettings)
		{
			this.fileSettings = fileSettings;
		}

		public void Save(int id, int hits)
		{
			io.File.AppendAllText(GetFilePath(), $"{id},{hits}\r\n");
		}

		public IEnumerable<Record> RetrieveAll()
		{
			var lines = io.File.ReadAllLines(GetFilePath());
			var linesSplit = lines.Select(l => l.Split(','));
			var records = linesSplit.Select(s => new Record(Int32.Parse(s[0]), Int32.Parse(s[1])));
			return records;
		}

		public void Clear()
		{
			io.File.WriteAllText(GetFilePath(), String.Empty);
		}

		private string GetFilePath()
		{
			return fileSettings.RootPath + "\\Registry.registry";
		}
	}
}
