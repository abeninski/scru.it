
namespace Model
{
    public class Comment : Entity
    {
        public int UserId { get; set; }

        public string Text { get; set; }

        public int PostId { get; set; }
    }
}
