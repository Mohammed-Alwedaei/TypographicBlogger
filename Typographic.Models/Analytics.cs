using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypographicBlogger.Models
{
    public class Analytics
    {

        public Guid Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public int WeeklyCreatedPosts { get; set; }

        public int MonthlyCreatedPosts { get; set; }

        public int YearlyCreatedPosts { get; set; }

    }
}
