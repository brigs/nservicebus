using System;
using NServiceBus.Example.Contracts;

namespace NServiceBus.Example.ConsoleSender
{
	class Program
	{
		public static IBus Bus { get; set; }

		static void Main(string[] args)
		{
			ConfigureBus();

			while (true)
			{
				Console.Write("Type message: ");
				var message = Console.ReadLine();
				
				Bus.Send(new NinjaMessage
				{
					Sender = "Console",
					Time = DateTime.Now,
					Message = message
				});

				Console.WriteLine("Message sent: " + message);
			}
		}

		private static void ConfigureBus()
		{
			Bus = Configure.With()
					 .Log4Net() // nservicebus will utilize log4net for logging.
					 .DefaultBuilder() // Tells NServiceBus to use autofac as IoC container.
					 .XmlSerializer() // Use XML for data format. (Recommended).
					 .MsmqTransport() // Use MSMQ for transport layer. NServiceBus supports other messaging systems as well.
					 .UnicastBus()
					 .SendOnly(); // TODO, explain this celestial being .SendOnly(); // TODO, explain this celestial being.
		}
	}
}
