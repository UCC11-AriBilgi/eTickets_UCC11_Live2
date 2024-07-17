using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Data.Static;
using eTickets.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    // 51
    [Authorize(Roles = UserRoles.Admin)] // Sadece Admin haklarına sahip olan kullanıcılar için
    public class MoviesController : Controller
    {
        // injecting
        // 16
        //private readonly AppDbContext _context;

        //public MoviesController(AppDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service= service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //var movieData = _context.Movies.ToList(); // VT den veri okunuyor
            // 17.1
            // Normal .ToList yapısıyla sadece Movie tablosundaki verileri çekiyoruz. Ama bize View ekranında Cinema adını da göstermemiz gerekiyor. Bu yüzden Include yapısı kullanıyoruz.
            
            //var movieData = _context.Movies.Include(c => c.Cinema).ToList(); // VT den veri okunuyor

            var moviesData=await _service.GetAllAsync(n=> n.Cinema); // ilişkilendirmeye girecek modelimi parametre olarak gönderiyoruz.Include property


            return View(moviesData);
        }

        [AllowAnonymous]
        // 38.3
        // Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            // Üzerine gelen id parametresine göre ilgi movie kayıdını VT den alacak ve View a gönderecek

            var movieDetails= await _service.GetMovieByIdAsync(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }
            
            return View(movieDetails);
        }

        // 38.4
        // Get : Movies/Create
        public async Task<IActionResult> Create()
        {
            // Controllerdan Create View ına oluşan dropdown bilgilerini aktarmam lazım ki görünebilsinler. 
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            // Oluşan dropdown içeriğini de ViewBag yöntemiyle View tarafına taşıyalım.
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas,"Id","Name");

            ViewBag.Producers = new SelectList(movieDropdownsData.Producers,"Id","FullName");
            
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors,"Id","FullName");

            return View();

        }

        // Post: Movie/Create
        [HttpPost]
        public async Task<IActionResult> Create (NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                // Herhangi bir Post anında eğer sayfada model durumum geçerli değilse(modele bazı uyumsuzluklar varsa) bu bloğa düşecektir. Dolayısı ile tekrardan View'a dönüş yapmak gerekecektir. Fakat View ekranındaki dropdownlist bilgileri ViewBag yöntemiyle oluşturulduğu için bu bilgiler Post işlemi sırasında ViewBag in bu tür durumlarda veri tutamadığı için kaybolacaktır. Dolayısı ile bunları tekrardan oluşturmalıyız.
                
                // Controllerdan Create View ına oluşan dropdown bilgilerini aktarmam lazım ki görünebilsinler. 
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                // Oluşan dropdown içeriğini de ViewBag yöntemiyle View tarafına taşıyalım.
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");

                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");

                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);

            }
            // Eğer durum uygunsa
            await _service.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }


        // 38.5
        // Get : Movie/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id); // Var mı / yok mu

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            // Update etme modunda olduğum için bulduğum movie bilgilerini gerekli View'a göndereceğim

            var data = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(acmo => acmo.ActorId).ToList()
            };

            //DropdownList kısmı
            // Controllerdan Create View ına oluşan dropdown bilgilerini aktarmam lazım ki görünebilsinler. 
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            // Oluşan dropdown içeriğini de ViewBag yöntemiyle View tarafına taşıyalım.
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");

            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");

            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(data);
        }

        // Post : Movie/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit (int id,NewMovieVM data)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                // Oluşan dropdown içeriğini de ViewBag yöntemiyle View tarafına taşıyalım.
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");

                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");

                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(data);
            }

            await _service.UpdateMovieAsync(data);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        // 38.6
        public async Task<IActionResult> Filter(string searchString)
        {
            // Burası film adı veya Description bilgileri üzerinde arama yapacak bölüm...

            // Öncelikle VT üzerindeki tüm Movie bilgilerini okuyalım.

            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            // searchString doldurulmadan da arama butonuna basılmış olabilir. Bunun dolu olup olmadığına bir bakalım.

            if (!string.IsNullOrEmpty(searchString))
            {
                // eğer doluysa Name ve Description bilgileri üzerinde küçük harfli olarak arama
                var filteredResult = allMovies
                            .Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                return View("Index",filteredResult);
                           
            }

            // Boş olarak bastıysa da
            return View("Index", allMovies);
        }
    }
}
