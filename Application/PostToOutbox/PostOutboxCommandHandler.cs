using Application.CreatePost;
using MediatR;

namespace Application.PostToOutbox
{
    public class PostOutboxCommandHandler : IRequestHandler<OutboxCommand<PostCommand>, bool>
    {
        public async Task<bool> Handle(OutboxCommand<PostCommand> request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Save the post-outbox in database");

            return await Task.FromResult(true);
        }
    }
}
