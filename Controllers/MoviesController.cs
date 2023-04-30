using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;

namespace Movies_Tickets_Ecommerce_App.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext context;

        public MoviesController(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index()
        {
            var MoviesList = await context.Movies.Include(m=>m.Cinema).ToListAsync();
            return View(MoviesList);
        }
    }
}
