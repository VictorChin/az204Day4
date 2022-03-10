// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.Messaging.EventGrid;

string topicEndpoint = "https://ourgrid.eastus2-1.eventgrid.azure.net/api/events";
string topicKey = "s/V688eCDYjidVbAd3tn+cy2l76rKWyzOx5wSwGrwOY=";
Uri endpoint = new Uri(topicEndpoint);
AzureKeyCredential credential = new AzureKeyCredential(topicKey);
EventGridPublisherClient client = new EventGridPublisherClient(endpoint, credential);
EventGridEvent firstEvent = new EventGridEvent(
    subject: $"New Employee: Alba Sutton",
    eventType: "Employees.Registration.New",
    dataVersion: "1.0",
    data: new
    {
        FullName = "Alba Sutton",
        Address = "4567 Pine Avenue, Edison, WA 97202"
    }
 );

EventGridEvent secondEvent = new EventGridEvent(
       subject: $"New Employee: Alexandre Doyon",
       eventType: "Employees.Registration.New",
       dataVersion: "1.0",
       data: new
       {
           FullName = "Alexandre Doyon",
           Address = "456 College Street, Bow, WA 98107"
       }
   );

EventGridEvent third = new EventGridEvent(
       subject: $"New Employee: Alexandre Doyon",
       eventType: "Employees.Leave",
       dataVersion: "1.0",
       data: new
       {
           FullName = "Alexandre Doyon",
           Address = "456 College Street, Bow, WA 98107",
           Duration = "7 days"
       }
   );

await client.SendEventAsync(firstEvent);
await client.SendEventAsync(secondEvent);
await client.SendEventAsync(third);