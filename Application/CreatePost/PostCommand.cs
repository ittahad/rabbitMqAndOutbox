using MassTransit;
using MediatR;
using MiniApp.Core;

namespace Application.CreatePost
{
    public class PostCommand : MinimalCommand
    {
        public string? Id { get; set; }
        public string? PostContent { get; set; }
    }
}