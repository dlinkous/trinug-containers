using System;

namespace OtherExamples.DesignVersusRun
{
	internal interface IFileSystem
	{
		void Save(string path, string content);
	}
}
