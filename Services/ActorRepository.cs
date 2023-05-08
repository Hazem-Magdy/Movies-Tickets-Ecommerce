using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Data.Base;
using Movies_Tickets_Ecommerce_App.Models;

namespace Movies_Tickets_Ecommerce_App.Services
{
    public class ActorRepository : EntityBaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(AppDbContext _db) : base(_db) { }
    }
}
