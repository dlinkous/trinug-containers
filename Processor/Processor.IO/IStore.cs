using System;

namespace Processor.IO
{
	public interface IStore
	{
		void Create(int id, string body);
		string Read(int id);
		void Clear();
	}
}
