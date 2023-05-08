using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Models;

namespace Movies_Tickets_Ecommerce_App.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext db;
        public EntityBaseRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<List<T>> GetAllAsync() => await db.Set<T>().ToListAsync();


        public async Task<T> GetByIDAsync(int id) => await db.Set<T>().FirstOrDefaultAsync(a => a.Id == id);

        public async Task<T> AddAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await db.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = db.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await db.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, T entity) 
        {
            EntityEntry entityEntry = db.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await db.SaveChangesAsync();
        }
        
    }
}
