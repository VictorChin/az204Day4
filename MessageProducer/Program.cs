
// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

string connectionString = "Endpoint=sb://norlysbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=xxNX+7O3YfkLaSP530HZ6Yh0GyGH4LxwGUrjkHiQkLM=";
string queueName = "bbq";
await using var client = new ServiceBusClient(connectionString);

// create the sender
ServiceBusSender sender = client.CreateSender(queueName);

// create a message that we can send
for (int i = 0; i < 50; i++)
{
    ServiceBusMessage message = new ServiceBusMessage($"Hello world!{i}");

    await sender.SendMessageAsync(message);
}


// send the message