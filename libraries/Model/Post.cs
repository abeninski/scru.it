
namespace Model
{
    public class Post : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string VisualUrl { get; set; }

        public int ScrewItCount { get; set; }

        public int ScrewYouCount { get; set; }
    }
}
