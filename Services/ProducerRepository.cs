using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Data.Base;
using Movies_Tickets_Ecommerce_App.Models;

namespace Movies_Tickets_Ecommerce_App.Services
{
    public class ProducerRepository:EntityBaseRepository<Producer>, IProducerRepository
    {
        

        public ProducerRepository(AppDbContext _db):base(_db)
        {
            
        }
    }
}
