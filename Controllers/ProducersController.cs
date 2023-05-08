using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Services;

namespace Movies_Tickets_Ecommerce_App.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerRepository repository;

        public ProducersController(IProducerRepository _repository) {

            repository = _repository;
        }
        public async Task<IActionResult>Index()
        {
            var ProducersList = await repository.GetAllAsync();
            return View(ProducersList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ProducerDetails = repository.GetByIDAsync(id);
            if(ProducerDetails == null)
            {
                return View("NotFound");
            }
            return View(ProducerDetails);
        }
    }
}
