using Application.Shared;
using MiniApp.Core;

namespace Application.AddComment
{
    public class CommentCommand : RedisMessage
    {
        public string? CommentContent { get; set; }
    }
}
