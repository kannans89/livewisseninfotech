using Azure.Messaging.ServiceBus;
using ConsoleTopicReceiverApp;
using Newtonsoft.Json;


string connectionString = "Endpoint=sb://wissentechsb2024.servicebus.windows.net/;SharedAccessKeyName=readPolicy;SharedAccessKey=FT+f8V4ys45MmZiANKiHGILv0SOsb8lgO+ASbE1udNg=;EntityPath=stocks";
string topicName = "stocks";
string subscriptionName = "subB";//change to ConsumerA,ConsumerB,ConsumerC

await ReceiveMessages();

async Task ReceiveMessages()
{
    ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);
    ServiceBusReceiver serviceBusReceiver = serviceBusClient.CreateReceiver(topicName, subscriptionName,
        new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });

    IAsyncEnumerable<ServiceBusReceivedMessage> messages = serviceBusReceiver.ReceiveMessagesAsync();

    await foreach (ServiceBusReceivedMessage message in messages)
    {

        Stock order = JsonConvert.DeserializeObject<Stock>(message.Body.ToString());
        Console.WriteLine("Order Id {0}", order.OrderID);
        Console.WriteLine("Quantity {0}", order.Quantity);
        Console.WriteLine("Unit Price {0}", order.UnitPrice);
        Console.WriteLine();
        //await Console.Out.WriteLineAsync();

    }
}
