using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    public interface IActorsService
    {
        // 20
        //IEnumerable<Actor> GetAll();
        //Actor GetById(int id);

        //void Add(Actor actor);

        //Actor Update(int id, Actor actor);
        //void Delete(int id);

        // 23
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);

        Task AddAsync(Actor actor);

        Task<Actor> UpdateAsync(int id, Actor actor);
        Task DeleteAsync(int id);
    }
}
