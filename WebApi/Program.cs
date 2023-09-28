using Application.CreatePost;
using Domain.Interfaces;
using Infrastructure;
using MediatR;
using MiniApp.Api;
using MiniApp.Core;
using MiniApp.MongoDB;
using MiniApp.Redis;
using WebApi;

var options = new MinimalWebAppOptions
{
    ConsoleLogging = true
};

var appBuilder = new MinimalWebAppBuilder(options);

var webApp = appBuilder.Build(builder => {  
    builder.Services.AddMediatR(typeof(PostCommand).Assembly);
    builder.Services.AddMongoDB();
    builder.Services.AddSingleton<IRedisClient, RedisClient>();

    builder.Services.AddSingleton<INotificationHelper, NotificationHelper>();
    builder.Services.AddSingleton<IStorageHelper, StorageHelper>();
});

webApp.Application!.MapGet("/", () => { 
    return "Running...";
});

webApp.Application!.RegisterRoutes();

webApp?.Start();
