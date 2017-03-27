using System;

namespace DomainEvents
{
	public interface IHandler<T> where T : IEvent
	{
		void Handle(T e);
	}
}
