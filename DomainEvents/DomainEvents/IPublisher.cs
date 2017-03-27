using System;

namespace DomainEvents
{
	public interface IPublisher
	{
		void Publish<T>(T e) where T : IEvent;
	}
}
