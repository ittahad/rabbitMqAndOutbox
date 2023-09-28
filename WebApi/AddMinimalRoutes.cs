using Application.AddComment;
using Application.CreatePost;
using Application.PostToOutbox;
using Application.Shared;
using Microsoft.AspNetCore.Mvc;
using MiniApp.Api;
using MiniApp.Core;
using System.Text.Json;

namespace WebApi
{
    public static class AddMinimalRoutes
    {
        public static void RegisterRoutes(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/postViaBroker", async (IMinimalMediator mediator,
                [FromBody] PostCommand postCommand) => { 

                await mediator.SendAsync(postCommand, Constants.QueueName);
                return "success";

            });

            builder.MapPost("/postViaOutbox", async (IMinimalMediator mediator,
                [FromBody] PostCommand postCommand) => { 
    
                var outboxCommand = new OutboxCommand<PostCommand>()
                {
                    Command = postCommand
                };
                _ = await mediator.SendAsync<OutboxCommand<PostCommand>, bool>(outboxCommand);
                return "success";
            });

            builder.MapPost("/postViaRedis", async (IRedisClient client,
                [FromBody] CommentCommand commentCommand) => { 
    
                    commentCommand.MessageType = commentCommand.GetType().FullName;
                _ = client.Publish(commentCommand.GetType().FullName!, JsonSerializer.Serialize(commentCommand));
                return "success";
            });
        }
    }
}
