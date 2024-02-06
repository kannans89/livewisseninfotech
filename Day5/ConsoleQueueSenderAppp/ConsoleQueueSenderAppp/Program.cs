//sender connection string:
using Azure.Messaging.ServiceBus;

const string connectionString = "Endpoint=sb://wissentechsb2024.servicebus.windows.net/;SharedAccessKeyName=senderPolicy;SharedAccessKey=zu+ZnZwrGkY7pJy2fWkmxGAnc6k9U+jE6+ASbMazzpY=;EntityPath=myorders";
const string queueName = "myorders";
ServiceBusClient? client = default;
ServiceBusSender? sender = default;
const int numOfMessages = 3;
client = new ServiceBusClient(connectionString);
sender = client.CreateSender(queueName);

using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

for (int i = 1; i <= numOfMessages; i++)
{
    if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
    {
        throw new Exception($"The message {i} is too large to fit in the batch.");
    }
}
try
{
    await sender.SendMessagesAsync(messageBatch);
    Console.WriteLine($"A batch of {numOfMessages} messages has been published to the queue.");
}
finally
{
    await sender.DisposeAsync();
    await client.DisposeAsync();
}