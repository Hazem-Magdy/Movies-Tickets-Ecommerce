using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Services;

namespace Movies_Tickets_Ecommerce_App.Controllers
{

    public class ActorsController : Controller
    {
        private readonly IActorRepository actorRepository;

        public ActorsController(IActorRepository _actorRepository) { 
            actorRepository = _actorRepository;
        }
        public async Task<IActionResult> Index()
        {
            var ActorsList = await actorRepository.GetAllAsync();
            return View(ActorsList);
        }
    }
}
