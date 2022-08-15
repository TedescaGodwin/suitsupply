using System;
using System.Net;
using System.Net.Http;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Suit.Supply.Function
{
    public class OrderPaidFunc
    {
        private readonly ILogger<OrderPaidFunc> _logger;

        public OrderPaidFunc(ILogger<OrderPaidFunc> log)
        {
            _logger = log;
        }

        [FunctionName("OrderPaidFunc")]
        public void Run([ServiceBusTrigger("sales-order-paid", 
            "sales-order-paid", 
            Connection = "Endpoint=sb://suits-ns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5T1HDeLMfBtsgvxKf1DFWrAmUdtQ9CflhW/IJy8Mnu4=")]
       ServiceBusReceivedMessage mySbMsg)
        {
            foreach (var item in mySbMsg.ApplicationProperties)
            {
                if (item.Key == "messageType" && (string)item.Value == "OrderPaid")
                {
                    _logger.LogInformation($"Update alteration status from pending to started: {mySbMsg}");
                }
            }
        }
    }
}
