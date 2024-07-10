using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        // injecting
        // 16
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cinemaData = _context.Cinemas.ToList(); // VT den veri okunuyor

            return View(cinemaData);
        }
    }
}
