using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context) 
        {
            _context = context;
        }

        // 21
        //public IEnumerable<Actor> GetAll()
        //{

        //}

        //public Actor GetById(int id)
        //{
        //    var actor = _context.Actors.FirstOrDefault(a => a.Id == id);

        //    return actor;
        //}

       //public void Add(Actor actor)
       // {
       //     _context.Actors.Add(actor);
       //     _context.SaveChanges(); // lazım ki değişiklikler VT ye yerleşsin
       // }

        //public Actor Update(int id, Actor actor)
        //{
        //    _context.Update(actor);

        //    _context.SaveChanges();

        //    return actor;
        //}

        //public void Delete(int id)
        //{
        //    var result=_context.Actors.FirstOrDefault(a=> a.Id == id);

        //    _context.Actors.Remove(result);

        //    _context.SaveChanges();
        //}


        //23
        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var actors = await _context.Actors.ToListAsync();

            return actors;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);

            return actor;
        }

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync(); // lazım ki değişiklikler VT ye yerleşsin
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            _context.Update(actor);

            await _context.SaveChangesAsync();

            return actor;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);

            _context.Actors.Remove(result);

            await _context.SaveChangesAsync();
        }
    }
}
