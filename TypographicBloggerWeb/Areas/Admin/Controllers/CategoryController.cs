using Microsoft.AspNetCore.Mvc;
using TypographicBlogger.DataAccess;
using TypographicBlogger.Models;

namespace TypographicBloggerWeb.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Category.ToList();

            return View(categories);
        }

        public IActionResult Upsert(int id)
        {

            if (id == 0)
            {
                return View();
            }
            else
            {
                Category category = _db.Category.FirstOrDefault(c => c.Id == id);
                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (category.Id == 0)
            {
                _db.Category.Add(category);
            }
            else
            {
                _db.Category.Update(category);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {

            Category category = _db.Category.FirstOrDefault(c => c.Id == id);
            
            return View(category);
                
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Category category)
        {

            _db.Category.Remove(category);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}