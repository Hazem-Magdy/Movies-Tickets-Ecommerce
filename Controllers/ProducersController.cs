using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Models;
using Movies_Tickets_Ecommerce_App.Services;

namespace Movies_Tickets_Ecommerce_App.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerRepository repository;

        public ProducersController(IProducerRepository _repository)
        {

            repository = _repository;
        }
        public async Task<IActionResult> Index()
        {
            var ProducersList = await repository.GetAllAsync();
            return View(ProducersList);
        }

        public async Task<IActionResult> Details(int id)
        {
            Producer ProducerDetails = await repository.GetByIDAsync(id);
            if (ProducerDetails == null)
            {
                return View("NotFound");
            }
            return View(ProducerDetails);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Producer producerDetails = await repository.GetByIDAsync(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            Producer producerDetails = await repository.GetByIDAsync(id);
            if (producerDetails == null) return View("NotFound");
            if (ModelState.IsValid)
            {
                await repository.UpdateAsync(id, producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Producer producerDetails = await repository.GetByIDAsync(id);
            if (producerDetails == null) return View("NotFound");
            
            return View(producerDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Producer producerDetails = await repository.GetByIDAsync(id);
            if (producerDetails == null) return View("NotFound");
            await repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public  IActionResult Create(int id) => View();

        [HttpPost]
        public async Task<IActionResult> Create(int id, Producer producer)
        {
            
            if (ModelState.IsValid)
            {
                await repository.AddAsync(producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }
    }
}

