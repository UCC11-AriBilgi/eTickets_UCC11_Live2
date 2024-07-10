using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    // 51
    [Authorize(Roles = UserRoles.Admin)] // Sadece Admin haklarına sahip olan kullanıcılar için
    public class CinemasController : Controller
    {
        // injecting
        // 16
        //private readonly AppDbContext _context;
        // 37.1
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service= service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cinemaData = await _service.GetAllAsync();

            return View(cinemaData);
        }

        // 37.2
        // Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // View dan gelen bilgileri yakala
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.AddAsync(cinema);

            return RedirectToAction(nameof(Index));

        }

        // 37.4
        // Get : Cinemas/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            return View(cinemaDetails);
        }

        // 37.5
        // Get : Cinemass/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            return View(cinemaDetails);
        }

        // 37.5
        // Post : Cinemas/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.UpdateAsync(id, cinema);

            return RedirectToAction(nameof(Index));
        }

        // 37.6
        // Get : Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            return View(cinemaDetails);

        }

        // 37.6
        // Post : Cinemas/Delete/1
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
