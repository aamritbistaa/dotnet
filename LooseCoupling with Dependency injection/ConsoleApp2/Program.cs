using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp
{
    public interface IServiceBroker
    {
        void Serve();
    }
    public class ServiceProvider : IServiceBroker
    {
        public void Serve()
        {
            Console.WriteLine("Service Started...");
        }
    }
    public class ServiceConsumer
    {
        private IServiceBroker _service;
        public void Start(IServiceBroker s)
        {
            this._service = s;
            Console.WriteLine("Service Called... by ");
            this._service.Serve();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            #region how?
/*
    Loose coupled design with interface 

            loose coupled - change in one doesnot effect on another

    Here is a interface IServiceBroker, it has been implemented by ServiceProvider class,
    ServiceProvider also provides the Serve function.
    There is another class ServiceConsumer, it has a private fied _service of type IServiceBroker and method called start 
    Start Method displays something in console and calls the method Serve from the class that is implementing IServiceBroker interface
        also this method start should be passed with object of class that implements this interface



*/
            #endregion

//Create object of Client class
            ServiceConsumer client = new ServiceConsumer();
            ServiceProvider s = new ServiceProvider();

            //Call to Start method with proper object.
            //client.Start(new ServiceProvider());
            client.Start(s);
            Console.ReadLine();
}
}

}