using System;
using System.Web.Mvc;
using NServiceBus;
using StructureMap;
using NServiceBus.Example.Contracts;

namespace NServiceBus.Example.Sender.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {            
			var bus = ObjectFactory.GetInstance<IBus>();
			bus.Send(new NinjaMessage {Sender = "Kjell Iver", Message = "Message.", Time = DateTime.Now});
        }
    }
}
