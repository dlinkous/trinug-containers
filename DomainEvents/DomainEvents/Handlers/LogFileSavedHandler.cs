using System;
using DomainEvents.Events;

namespace DomainEvents.Handlers
{
	public class LogFileSavedHandler : IHandler<FileSavedEvent>
	{
		public void Handle(FileSavedEvent e)
		{
			Console.WriteLine($"Logging that this file was saved: {e.FileName}");
		}
	}
}
