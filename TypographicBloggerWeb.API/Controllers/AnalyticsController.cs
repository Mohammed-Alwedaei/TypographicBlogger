using Microsoft.AspNetCore.Mvc;
using TypographicBlogger.DataAccess;
using TypographicBlogger.Models;
using TypographicBlogger.Models;

namespace TypographicBlogger.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyticsController : ControllerBase
    {
        public readonly ApplicationDbContext _db;

        public AnalyticsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost(Name = "PostAnalytics")]
        public IActionResult Post(Analytics analytics)
        {

            //var posts = _db.Analytics;

            /*foreach (var post in posts)
            {
                var month = post.DateCreated.Month;

                /*switch (month)
                {
                    case 
                }
            }*/

            analytics.Id = Guid.NewGuid();

            analytics.WeeklyCreatedPosts = 3;

            analytics.MonthlyCreatedPosts = 12;

            analytics.YearlyCreatedPosts = 50;


            _db.Analytics.Add(analytics);

            return StatusCode(200);
        }

            
        

        [HttpGet(Name = "GetAnalytics")]
        public IEnumerable<Analytics> Get()
        {
            var analytics = _db.Analytics;

            return analytics.ToArray();
        }
    }
}
