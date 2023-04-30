using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;

namespace Movies_Tickets_Ecommerce_App.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext context;

        public ProducersController(AppDbContext _context) {

            context = _context;
        }
        public async Task<IActionResult>Index()
        {
            var ProducersList = await context.Producers.ToListAsync();
            return View(ProducersList);
        }
    }
}
