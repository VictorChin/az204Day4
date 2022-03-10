// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

string connectionString = "Endpoint=sb://norlysbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=xxNX+7O3YfkLaSP530HZ6Yh0GyGH4LxwGUrjkHiQkLM=";
string queueName = "bbq";
await using var client = new ServiceBusClient(connectionString);
ServiceBusReceiver receiver = client.CreateReceiver(queueName);

// the received message is a different type as it contains some service set properties
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
Console.WriteLine(receivedMessage.Body);
// complete the message, thereby deleting it from the service
await receiver.CompleteMessageAsync(receivedMessage);
