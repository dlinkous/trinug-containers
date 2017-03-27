using System;
using DomainEvents.Events;

namespace DomainEvents.Handlers
{
	public class EmailFileSavedHandler : IHandler<FileSavedEvent>
	{
		public void Handle(FileSavedEvent e)
		{
			Console.WriteLine($"I just sent an E-Mail about: {e.FileName}");
		}
	}
}
