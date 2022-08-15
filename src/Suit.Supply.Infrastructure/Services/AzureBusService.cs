using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Suit.Supply.Core.SalesAggregate;
using Suit.Supply.Core.SalesAggregate.Models;
using System.Text.Json;

namespace Suit.Supply.Infrastructure.Services
{
    public class AzureBusService : IAzureBusService
    {
        private readonly IMyServiceBusClient _myServiceBusClient;

        public AzureBusService(IMyServiceBusClient myServiceBusClient)
        {
            _myServiceBusClient = myServiceBusClient;
        }

        public async Task ReceiveMessageAsync(string topic)
        {
            //I do not want to do this part
            ServiceBusReceiver receiver = _myServiceBusClient.CreateReceiver(topic);

            // the received message is a different type as it contains some service set properties
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            // get the message body as a string
            _ = receivedMessage.Body.ToString();
        }

        public async Task SendMessageAsync(SalesDetail msg, string topic)
        {
            // create the sender
            ServiceBusSender sender = _myServiceBusClient.CreateSender(topic);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new(JsonSerializer.Serialize(msg));
            message.ApplicationProperties.Add("messageType", 
                msg.OrderStatus == OrderStatus.OrderPaid ? "OrderPaid" : 
                msg.OrderStatus == OrderStatus.Done ? "AlterationFinished" : "OrderPending");

            // send the message
            await sender.SendMessageAsync(message);
        }
    }
}