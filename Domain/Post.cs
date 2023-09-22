using MiniApp.Core;

namespace Domain
{
    public class Post
    {
        public string? Id { get; set; }
        public string? PostContent { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}