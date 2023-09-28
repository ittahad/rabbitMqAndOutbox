using MiniApp.Core;

namespace Application.PostToOutbox
{
    public class OutboxCommand<T> : MinimalQuery<bool>
    {
        public T? Command { get; set; }
    }
}
