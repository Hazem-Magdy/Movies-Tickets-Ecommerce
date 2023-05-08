using Movies_Tickets_Ecommerce_App.Data.Base;
using Movies_Tickets_Ecommerce_App.Models;

namespace Movies_Tickets_Ecommerce_App.Services
{
    public interface IActorRepository:IEntityBaseRepository<Actor>
    {
        Task<List<Actor>> GetAllAsync();
        Task<Actor> GetByIDAsync(int id);
        Task<Actor> AddAsync(Actor actor);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Actor actor);
    }
}