using Domain;
using MiniApp.Core;

namespace Application.AddComment
{
    public class CommentCommandHandler : MinimalCommandHandler<CommentCommand, bool>
    {
        private readonly IAppDbContext _appDbContext;

        public CommentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public override async Task<bool> Handle(CommentCommand message)
        {
            Console.WriteLine("Save the post in database");

            var comment = new Comment(
                Guid.NewGuid().ToString(),
                message.CommentContent!,
                DateTime.UtcNow);

            await _appDbContext.SaveItem(comment, "TenantId");

            Console.WriteLine("Notify the tagged members");

            Console.WriteLine("Compress the post thumbnails");

            Console.WriteLine("And many more...");

            return await Task.FromResult(true);
        }
    }
}
