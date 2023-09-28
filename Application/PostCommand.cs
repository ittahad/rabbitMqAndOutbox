using MassTransit;
using MediatR;
using MiniApp.Core;

namespace Application
{
    public class PostCommand : MinimalCommand
    {
        public string? Id { get; set; }
        public string? PostContent { get; set; }
    }

    public class CommentCommand : RedisMessage
    {
        public string? CommentContent { get; set; }
    }


    public class OutboxCommand<T> : MinimalQuery<bool>
    {
        public T? Command { get; set; }
    }

    public abstract class RedisMessage : MinimalCommand
    {
        public string? Id { get; set; }
        public string? MessageType { get; set; }
    }
}