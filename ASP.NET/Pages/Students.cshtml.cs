using System.Linq.Expressions;
using ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Pages
{
    public class StudentsModel : PageModel
    {
        private readonly SchoolContext _context;

        public List<Student> StudentsList { get ; set ; } = new List<Student>();

        [BindProperty]
        public Student NewStudent { get; set; }

        public StudentsModel(SchoolContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            StudentsList = _context.Students.ToList();
        }

        public IActionResult OnPost()
        {
            _context.Students.Add(NewStudent);

            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}
