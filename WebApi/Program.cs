using Application;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniApp.Api;
using MiniApp.Core;
using MiniApp.MongoDB;

var options = new MinimalWebAppOptions
{
    ConsoleLogging = true
};

var appBuilder = new MinimalWebAppBuilder(options);

var webApp = appBuilder.Build(builder => {  
    builder.Services.AddMediatR(typeof(PostCommand).Assembly);
    builder.Services.AddMongoDB();
});

webApp.Application!.MapGet("/", () => { 
    return "Running...";
});

webApp.Application!.MapPost("/postViaBroker", async (IMinimalMediator mediator,
    [FromBody] PostCommand postCommand) => { 

    await mediator.SendAsync(postCommand, Constants.QueueName);
    return "success";

});

webApp.Application!.MapPost("/postViaOutbox", async (IMinimalMediator mediator,
    [FromBody] PostCommand postCommand) => { 
    
    var outboxCommand = new OutboxCommand<PostCommand>()
    {
        Command = postCommand
    };
    _ = await mediator.SendAsync<OutboxCommand<PostCommand>, bool>(outboxCommand);
    return "success";
});

webApp?.Start();
