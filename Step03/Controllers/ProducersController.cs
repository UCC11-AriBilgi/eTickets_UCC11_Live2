using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        // injecting
        // 16
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var producerData = _context.Producers.ToList(); // VT den veri okunuyor

            return View(producerData);
        }
    }
}
