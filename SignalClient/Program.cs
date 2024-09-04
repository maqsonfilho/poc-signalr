using Microsoft.AspNetCore.SignalR.Client;
using SignalClient;

const string url = "https://localhost:7180/hubs/center-management";

Console.WriteLine("Hello, World!");

await using var connection = new HubConnectionBuilder()
    .WithUrl(url)
    .WithAutomaticReconnect()
    .Build();

await connection.StartAsync();

connection.On<LoadScheduleStatusResponse>("setStatus", (response) =>
{
    Console.WriteLine($"Date: {response.Date}" +
        //$"\nLoadId: {response.LoadId}" +
        $"\nPlate: {response.VehiclePlate}" +
        $"\nStatus: {response.Status}\n\n" );
});

connection.On<string>("setClientMessage", (response) =>
{
    Console.WriteLine($"{response}\n\n");
});

Console.ReadLine();