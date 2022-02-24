using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using TypographicBlogger.Models;

namespace TypographicBlogger.ViewModels
{
    public class BlogPostViewModel
    {

        public Post Post { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }

    }
}
