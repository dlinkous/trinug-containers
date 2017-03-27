using System;
using System.Collections.Generic;

namespace Processor.IO
{
	public interface IRegistry
	{
		void Save(int id, int hits);
		IEnumerable<Record> RetrieveAll();
		void Clear();
	}
}
