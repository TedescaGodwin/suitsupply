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
    public class AlterationFinishedFunc
    {
        private readonly ILogger<AlterationFinishedFunc> _logger;

        public AlterationFinishedFunc(ILogger<AlterationFinishedFunc> log)
        {
            _logger = log;
        }

        [FunctionName("AlterationFinishedFunc")]
        public void Run([ServiceBusTrigger("alteration-order-finished", 
            "order-completed", 
            Connection = "Endpoint=sb://suits-ns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5T1HDeLMfBtsgvxKf1DFWrAmUdtQ9CflhW/IJy8Mnu4=")]
            ServiceBusReceivedMessage mySbMsg)
        {
                foreach (var item in mySbMsg.ApplicationProperties)
                {
                    if (item.Key == "messageType" && (string)item.Value == "AlterationFinished")
                    {
                        _logger.LogInformation($"Send Email for completed item: {mySbMsg}");

                    HttpRequestMessage request = new();
                    try
                    {
                        // Convert all request param into Json object
                       
                        var content = request.Content;
                        string jsonContent = content.ReadAsStringAsync().Result;
                        dynamic requestPram = JsonConvert.DeserializeObject<CompletedOrderParam>(jsonContent);


                        if ((int)requestPram.SalesId != 0)
                        {
                            request.CreateResponse(HttpStatusCode.OK, "Please enter the valid Sales Id!");
                        }
                        // Call an API to send email
                        HttpClient newClient = new HttpClient();
                        HttpRequestMessage newRequest = new HttpRequestMessage(HttpMethod.Post, 
                            string.Format("http://localhost:8080/email?salesId={0}?to={1}&from={2}&body{3}",
                            requestPram.SalesId, 
                            requestPram.to,
                            requestPram.from,
                            requestPram.body));

                    }
                    catch (Exception ex)
                    {
                        request.CreateResponse(HttpStatusCode.OK, "Invaild Sales Id! Reason: {0}", string.Format(ex.Message));
                    }
                }

            }

        }
    }
}
