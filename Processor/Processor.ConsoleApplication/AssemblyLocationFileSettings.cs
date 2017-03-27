using System;
using System.IO;
using System.Reflection;
using Processor.IO.File;

namespace Processor.ConsoleApplication
{
	internal class AssemblyLocationFileSettings : IFileSettings
	{
		public string RootPath
		{
			get
			{
				return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			}
		}
	}
}
