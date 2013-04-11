using System;
using NServiceBus;

namespace NServiceBus.Example.Contracts
{
	public class PublisherMessage : IEvent
	{
		public string Sender { get; set; }
		public string Message { get; set; }
		public DateTime Time { get; set; }
	}
}
