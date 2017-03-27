using System;
using io = System.IO;

namespace Processor.IO.File
{
	public class FileStore : IStore
	{
		private readonly IFileSettings fileSettings;

		public FileStore(IFileSettings fileSettings)
		{
			this.fileSettings = fileSettings;
		}

		public void Create(int id, string body)
		{
			var path = GetFilePath(id);
			io.File.WriteAllText(path, body);
		}

		public string Read(int id)
		{
			var path = GetFilePath(id);
			return io.File.ReadAllText(path);
		}

		public void Clear()
		{
			foreach (var stored in io.Directory.EnumerateFiles(fileSettings.RootPath, "*.stored"))
			{
				io.File.Delete(stored);
			}
		}

		private string GetFilePath(int id)
		{
			return $"{fileSettings.RootPath}\\{id}.stored";
		}
	}
}
