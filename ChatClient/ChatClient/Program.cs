// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Microsoft.AspNetCore.SignalR.Client;
using System;

class Program
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5067/chatHub")
            .Build();

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}: {message}");
        });

        await connection.StartAsync();

        while (true)
        {
            var message = Console.ReadLine();
            await connection.InvokeAsync("SendMessage", "ConsoleClient", message);
        }
    }
}

