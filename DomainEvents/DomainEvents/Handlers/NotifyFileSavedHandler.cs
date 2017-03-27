using System;
using DomainEvents.Events;

namespace DomainEvents.Handlers
{
	public class NotifyFileSavedHandler : IHandler<FileSavedEvent>
	{
		public void Handle(FileSavedEvent e)
		{
			Console.WriteLine($"Notifying someone via text message that this file saved: {e.FileName}");
		}
	}
}
