using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;

namespace RestHost
{
    class Program
    {
        static void Main()
        {
            WebServiceHost host = new WebServiceHost(typeof(HelloRestService.HelloRestService),
               new Uri("http://localhost:8082"));

            ServiceEndpoint ep = host.AddServiceEndpoint(
                typeof(HelloRestService.IHelloRestService), new WebHttpBinding(), "");

            host.Description.Endpoints[0].Behaviors.Add(new WebHttpBehavior { HelpEnabled = true });
            //Visar vilka metoder som använder vilken metod, vilket språk den kommunicerar på, om body är wrapped eller inte

            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.IncludeExceptionDetailInFaults = true;
            //sdb.HttpHelpPageEnabled = true; 

            host.Open();
            Console.WriteLine("Service is running ;)");
            Console.ReadKey();
            host.Close();
        }
    }
}
