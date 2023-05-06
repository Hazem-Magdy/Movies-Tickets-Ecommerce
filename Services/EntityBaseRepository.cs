using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Models;

namespace Movies_Tickets_Ecommerce_App.Services
{
    public class EntityBaseRepository<T>: IEntityBaseRepository<T> where T : class, IEntityBase, new()
    { 
        private readonly AppDbContext db;
        public EntityBaseRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await db.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<T> AddAsync(T entity)
        {
            db.Set<T>().AddAsync(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await db.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }
        public async Task UpdateAsync(int id, T entity) { }
        //public async Task UpdateAsync(int id, T entity)
        //{
        //    Actor oldActor = await db.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
        //    oldActor.ProfilePictureURL = actor.ProfilePictureURL;
        //    oldActor.FullName = actor.FullName;
        //    oldActor.Bio = actor.Bio;
        //    db.SaveChanges();
        //}
    }
}
