using MiniApp.Core;

namespace Application.CreatePost
{
    public class PostCommandHandler : MinimalCommandHandler<PostCommand, bool>
    {
        public override async Task<bool> Handle(PostCommand message)
        {
            Console.WriteLine("Save the post in database");

            Console.WriteLine("Notify the tagged members");

            Console.WriteLine("Compress the post thumbnails");

            Console.WriteLine("And many more...");

            return await Task.FromResult(true);
        }
    }
}
