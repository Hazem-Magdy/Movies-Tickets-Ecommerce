using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Models;

namespace Movies_Tickets_Ecommerce_App.Services
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext db;
        public ActorRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<List<Actor>> GetAllAsync()
        {
            return await db.Actors.ToListAsync();
        }
        public async Task<Actor> GetByIDAsync(int id)
        {

            return await db.Actors.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task DeleteAsync(int id)
        {

            Actor actor = await db.Actors.FirstOrDefaultAsync(a => a.Id == id);
            db.Actors.Remove(actor);
            await db.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, Actor newActor)
        {
            db.Update(newActor);
            await db.SaveChangesAsync();

        }

        public async Task<Actor> AddAsync(Actor actor)
        {
            await db.Actors.AddAsync(actor);
            await db.SaveChangesAsync();
            return actor;
        }


    }
}
