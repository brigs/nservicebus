using System;
using NServiceBus;
using NServiceBus.Example.Contracts;

namespace NServiceBus.Example.Publisher
{
	public class Publish : IWantToRunAtStartup
	{
		public IBus Bus { get; set; }

		public void Run()
		{
			while (true)
			{
				Bus.Publish(new PublisherMessage
					{
						Sender = "Publisher",
						Message = "This is a message from the publisher.",
						Time = DateTime.Now
					});
				System.Threading.Thread.Sleep(15000);
			}
		}

		public void Stop()
		{
		}
	}
}
