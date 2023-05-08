using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Models;
using Movies_Tickets_Ecommerce_App.Services;

namespace Movies_Tickets_Ecommerce_App.Controllers
{

    public class ActorsController : Controller
    {
        private readonly IActorRepository actorRepository;

        public ActorsController(IActorRepository _actorRepository)
        {
            actorRepository = _actorRepository;
        }
        public async Task<IActionResult> Index()
        {
            List<Actor> ActorsList = await actorRepository.GetAllAsync();
            return View(ActorsList);
        }

        public async Task<IActionResult> Details(int id)
        {
            Actor ActorDetails = await actorRepository.GetByIDAsync(id);
            if (ActorDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorDetails);
        }
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                await actorRepository.AddAsync(actor);
                return RedirectToAction("Index");
            }
            return View(actor);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Actor actorDetails = await actorRepository.GetByIDAsync(id);
            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            Actor actorDetails = await actorRepository.GetByIDAsync(id);
            if (actorDetails != null)
            {
                await actorRepository.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            return View("NotFound");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Actor existActor = await actorRepository.GetByIDAsync(id);
            if (existActor == null) return View("NotFound");
           
            return View(existActor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if (ModelState.IsValid)
            {
                await actorRepository.UpdateAsync(id, actor);
                return RedirectToAction("Index");
            }
            return View(actor);


        }
    }
}


