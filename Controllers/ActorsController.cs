using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;

namespace Movies_Tickets_Ecommerce_App.Controllers
{

    public class ActorsController : Controller
    {
        private readonly AppDbContext context;

        public ActorsController(AppDbContext _context) {

            context = _context; 
        }
        public async Task<IActionResult> Index()
        {
            var ActorsList = await context.Actors.ToListAsync();
            return View(ActorsList);
        }
    }
}
