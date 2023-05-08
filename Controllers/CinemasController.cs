using Microsoft.AspNetCore.Mvc;
using Movies_Tickets_Ecommerce_App.Models;
using Movies_Tickets_Ecommerce_App.Services;

namespace Movies_Tickets_Ecommerce_App.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaRepositoray cinemasRepositoray;

        public CinemasController(ICinemaRepositoray _cinemasRepositoray)
        {
            cinemasRepositoray = _cinemasRepositoray;
        }
        public async Task<IActionResult> Index()
        {
            List<Cinema> cinemasList = await cinemasRepositoray.GetAllAsync();
            return View(cinemasList);
        }
        public async Task<IActionResult> Details(int id)
        {
            Cinema cinemaDetails = await cinemasRepositoray.GetByIDAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }
        [HttpGet]
        public IActionResult Create() => View();
        
        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await cinemasRepositoray.AddAsync(cinema);
                return RedirectToAction("Index");
            }
            return View(cinema);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Cinema cinemaDetails = await cinemasRepositoray.GetByIDAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            Cinema cinemaDetails = await cinemasRepositoray.GetByIDAsync(id);
            if (cinemaDetails != null)
            {
                await cinemasRepositoray.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            return View("NotFound");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Cinema cinemaDetails = await cinemasRepositoray.GetByIDAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await cinemasRepositoray.UpdateAsync(id, cinema);
                return RedirectToAction("Index");
            }
            return View(cinema);
        }
    }
}
