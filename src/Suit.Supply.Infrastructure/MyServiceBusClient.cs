using Azure.Messaging.ServiceBus;

namespace Suit.Supply.Infrastructure
{
    public interface IMyServiceBusClient
    {
        ServiceBusSender CreateSender(string queName);
        ServiceBusReceiver CreateReceiver(string queueName);
    }
    public class MyServiceBusClient : ServiceBusClient, IMyServiceBusClient
    {
        public MyServiceBusClient(string connString) : base(connString)
        {
        }
        public override ServiceBusSender CreateSender(string queName)
        {
            return base.CreateSender(queName);
        }
        public override ServiceBusReceiver CreateReceiver(string queueName)
        {
            return base.CreateReceiver(queueName);
        }
    }
}
