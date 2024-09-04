using Microsoft.AspNetCore.SignalR;
using SignalServer;
using SignalServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});
var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.MapHub<ChatHub>("hubs/center-management");
app.UseCors("AllowAllOrigins");

app.Lifetime.ApplicationStarted.Register(() =>
{
    var serviceProvider = app.Services;
    var chatHub = serviceProvider.GetRequiredService<IHubContext<ChatHub>>();

    var timer = new System.Timers.Timer(1000);
    timer.Elapsed += async (sender, e) =>
    {
        // O uso de "await" é necessário para a chamada assíncrona.

        Random rnd = new();
        LoadScheduleStatusResponse response = new LoadScheduleStatusResponse
        {
            LoadId = rnd.Next(),
            VehiclePlate= "HUU-4232",
            Status = (CenterManagementStatus)rnd.Next(1, 8),
            Date = DateTime.Now
        };

        await chatHub.Clients.All.SendAsync("setStatus", response);
    };

    timer.Start();
});

app.Run();