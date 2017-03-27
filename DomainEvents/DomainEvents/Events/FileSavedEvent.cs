using System;

namespace DomainEvents.Events
{
	public class FileSavedEvent : IEvent
	{
		public string FileName { get; private set; }

		public FileSavedEvent(string fileName)
		{
			FileName = fileName;
		}
	}
}
