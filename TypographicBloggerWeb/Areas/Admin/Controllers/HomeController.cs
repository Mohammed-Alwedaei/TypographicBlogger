using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TypographicBlogger.DataAccess;
using TypographicBlogger.Models;
using TypographicBlogger.ViewModels;
using TypographicBlogger.Models;

namespace TypographicBloggerWeb.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment, ApplicationDbContext db)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Post> posts = _db.Posts.Include(p => p.Category).ToList();

            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {

            BlogPostViewModel blogPostViewModel = new BlogPostViewModel()
            {

                Post = new(),
                Categories = _db.Category.Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }),

            };

            return View(blogPostViewModel);
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult Create(BlogPostViewModel blogPostViewModel, IFormFile? formFile)
        {

            if (ModelState.IsValid)
            {

                var wwwRootFile = _hostEnvironment.WebRootPath;

                if (formFile != null)
                {
                    //Generate a new name
                    string fileName = Guid.NewGuid().ToString();

                    //Combine path to upload the file to
                    var uploadTo = Path.Combine(wwwRootFile, @"posts\images");

                    //Get the extension
                    var extension = Path.GetExtension(formFile.FileName);

                    //Use stream to copy the file
                    using (var filestream = new FileStream(Path.Combine(uploadTo, fileName + extension), FileMode.Create))
                    {
                        formFile.CopyTo(filestream);
                    }

                    blogPostViewModel.Post.ImageUrl = @"\posts\images\" + fileName + extension;
                }

            }

            _db.Posts.Add(blogPostViewModel.Post);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Details(string slug)
        {

            var post = _db.Posts.FirstOrDefault(p => p.Slug == slug);

            return View(post);
        }

        public IActionResult Upsert(string slug)
        {

            var post = _db.Posts.FirstOrDefault(p => p.Slug == slug);

            return View(post);
        }

        [HttpPost]
        [ActionName("Upsert")]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertPost(Post post)
        {

            _db.Posts.Update(post);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string slug)
        {
            var post = _db.Posts.FirstOrDefault(p => p.Slug == slug);

            return View(post);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(Post post)
        {

            _db.Posts.Remove(post);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #region API Calls

        [HttpGet]

        public IActionResult Posts()
        {
            var posts = _db.Posts.Include(p => p.Category);

            return Json(new { data = posts });
        }


        
        #endregion

    }
}