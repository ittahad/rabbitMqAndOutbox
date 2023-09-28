using MinimalHost;
using System.Reflection;
using MediatR;
using MiniApp.Core;
using Infrastructure;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Worker;
using MiniApp.Api;
using MiniApp.Redis;

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
                services.AddSingleton<IRedisClient, RedisClient>();
                services.RegisterRedisMessages(typeof(CommentCommand).Assembly);
            });
        }, messageHandlerAssembly: typeof(PostCommand).Assembly);

builder.Run();

