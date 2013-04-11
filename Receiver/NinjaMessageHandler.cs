using System;
using NServiceBus;
using NServiceBus.Example.Contracts;

namespace NServiceBus.Example.Receiver
{
	public class NinjaMessageHandler : IHandleMessages<NinjaMessage>
	{
		public void Handle(NinjaMessage message)
		{
			Console.WriteLine(message.Sender + " (" + message.Time + "): " + message.Message);
		}
	}
}
