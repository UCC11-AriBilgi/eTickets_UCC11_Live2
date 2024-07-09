using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller // Controller sınıfından  inherit
    {
        // 16 - injecting
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;    
        }

        // 17
        public IActionResult Index()
        {
            var actorData=_context.Actors.ToList(); // VT den veri okunuyor

            return View(actorData);
        }
    }
}
