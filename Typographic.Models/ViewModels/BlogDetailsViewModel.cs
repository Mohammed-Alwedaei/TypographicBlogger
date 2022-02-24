using TypographicBlogger.Models;

namespace TypographicBloggerWeb.ViewModels
{
    public class BlogDetailsViewModel
    {

        public IEnumerable<Post> PostDetails { get; set; }

        public Category Category { get; set; }

    }
}
