using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        // injecting
        // 16
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var movieData = _context.Movies.ToList(); // VT den veri okunuyor
            // 17.1
            // Normal .ToList yapısıyla sadece Movie tablosundaki verileri çekiyoruz. Ama bize View ekranında Cinema adını da göstermemiz gerekiyor. Bu yüzden Include yapısı kullanıyoruz.
            
            var movieData = _context.Movies.Include(c => c.Cinema).ToList(); // VT den veri okunuyor


            return View(movieData);
        }
    }
}
