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
            db.SaveChanges();
        }
        public async Task UpdateAsync(int id, Actor actor)
        {

            Actor oldActor = await db.Actors.FirstOrDefaultAsync(a => a.Id == id);
            oldActor.ProfilePictureURL = actor.ProfilePictureURL;
            oldActor.FullName = actor.FullName;
            oldActor.Bio = actor.Bio;
            db.SaveChanges();

        }

        public async Task<int> AddAsync(Actor actor)
        {
            db.Actors.Add(actor);
            db.SaveChanges();
            return actor.Id;
        }

        
    }
}
