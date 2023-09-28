using Application.CreatePost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Worker
{
    public class PostsHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public PostsHostedService(IServiceProvider serviceProvider) 
        { 
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var postsCommandHandler = scope.ServiceProvider.GetService<PostCommandHandler>();

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(10_000);
                
                // fetch the post info from database
                
                // construct the post command by batch fetching
                var postCommand = new PostCommand() {
                    Id = "", // From db,
                    PostContent = "" // From db
                };
                await postsCommandHandler!.Handle(postCommand);

                // Update the outbox for posts
            }

            Console.WriteLine("Stopped");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopped");
            return Task.CompletedTask;
        }
    }
}
