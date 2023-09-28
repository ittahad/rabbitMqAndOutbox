using MiniApp.Core;

namespace Application.Shared
{
    public abstract class RedisMessage : MinimalCommand
    {
        public string? Id { get; set; }
        public string? MessageType { get; set; }
    }
}
