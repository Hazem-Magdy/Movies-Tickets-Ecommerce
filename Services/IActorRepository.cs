using Movies_Tickets_Ecommerce_App.Models;

namespace Movies_Tickets_Ecommerce_App.Services
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAllAsync();
        Task<Actor> GetByIDAsync(int id);
        Task<int> AddAsync(Actor actor);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Actor actor);
    }
}