using MinimalHost;
using System.Reflection;
using MediatR;
using MiniApp.Core;
using Infrastructure;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Worker;

var options = new MinimalHostOptions
{
    ConsoleLogging = true
};

var builder = new MinimalHostingBuilder(options)
    .ListenOn(Constants.QueueName, prefetch: 10)
    .Build(
        hostBuilder: hostBuilder => { 
            hostBuilder.ConfigureServices((ctx, services) =>
            {
                services.AddMediatR(Assembly.GetEntryAssembly()!);
                services.AddMediatR(Assembly.GetExecutingAssembly());
                services.AddHostedService<PostsHostedService>();
            });
        },
        messageHandlerAssembly: typeof(PostCommand).Assembly);

builder.Run();

