using System;
using NServiceBus;

namespace NServiceBus.Example.Contracts
{
    public class NinjaMessage : IMessage
    {
		public string Sender { get; set; }
		public string Message { get; set; }
		public DateTime Time { get; set; }
    }
}
