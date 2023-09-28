using MiniApp.Core;

namespace Domain
{
    public class Comment
    {
        public Comment(string _id, string _content, DateTime _createDate) 
        { 
            Id = _id;
            CommentContent = _content;
            CreateDate = _createDate;
        }

        public string? Id { get; private set; }
        public string? CommentContent { get; private set; }
        public DateTime? CreateDate { get; private set; }
    }
}