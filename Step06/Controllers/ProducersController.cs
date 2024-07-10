using eTickets.Data;
using eTickets.Data.Static;
using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    // 51
    [Authorize(Roles = UserRoles.Admin)] // Sadece Admin haklarına sahip olan kullanıcılar için
    public class ProducersController : Controller
    {
        // injecting
        // 16
        //private readonly AppDbContext _context;
        private readonly IProducersService _service; // 36.1

        public ProducersController(IProducersService service)
        {
            //_context = context;
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var producerData = await _service.GetAllAsync();

            return View(producerData);
        }

        // 36.2
        // Get: Producerss/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // View dan gelen bilgileri yakala
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.AddAsync(producer);

            return RedirectToAction(nameof(Index));

        }

        // 36.4
        // Get : Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            return View(producerDetails);
        }

        // 36.5
        // Get : Producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            return View(producerDetails);
        }

        // 36.5
        // Post : Producers/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.UpdateAsync(id, producer);

            return RedirectToAction(nameof(Index));
        }

        // 36.6
        // Get : Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            return View(producerDetails);

        }

        // 36.6
        // Post : Actors/Delete/1
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
