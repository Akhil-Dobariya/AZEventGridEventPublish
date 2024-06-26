﻿using Azure;
using Azure.Messaging.EventGrid;
using System;
using System.Threading.Tasks;

namespace AZEventGridEventPublish
{
    class Program
    {
        static async Task Main(string[] args)
        {

            EventGridPublisherClient publisherClient = new EventGridPublisherClient(
                new Uri("Your EventGrid Topic Endpoint URL"),
                new AzureKeyCredential("Access Keys"));

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Event sending {i}");

                EventGridEvent eventGridEvent = new EventGridEvent("LearningEventSubject",
                "Learning.EventGrid.Test",
                "1.0",
                $"[Test Event Data {i}]");

                await publisherClient.SendEventAsync(eventGridEvent);

                Console.WriteLine($"Event sent {i}");
            }

            Console.WriteLine("Press any key to Exit");
            Console.ReadLine();
        }
    }
}
