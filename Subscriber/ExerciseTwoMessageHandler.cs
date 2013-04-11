using System;using NServiceBus;
using NServiceBus.Example.Contracts;


namespace NServiceBus.Example.Subscriber
{
	public class ExerciseTwoMessageHandler : IHandleMessages<PublisherMessage>
	{
		public void Handle(PublisherMessage message)
		{
			Console.WriteLine(message.Sender + " (" + message.Time + "): " + message.Message);
		}
	}
}
