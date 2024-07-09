using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller // Controller sınıfından  inherit
    {
        // 16 - injecting
        //private readonly AppDbContext _context;

        //public ActorsController(AppDbContext context)
        //{
        //    _context = context;    
        //}

        // 22
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
                _service = service;
        }

        // 17
        //public IActionResult Index()
        //{
        //    var actorData=_context.Actors.ToList(); // VT den veri okunuyor

        //    return View(actorData);
        //}

        // 22
        public async Task<IActionResult> Index()
        {
            //var actorsData = _service.GetAllAsync(); // Artık Service yapısı kullanılıyor.

            //23
            var actorsData = await _service.GetAllAsync(); // Artık Service yapısı kullanılıyor.

            return View(actorsData);
        }

        // 24
        // Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // View dan gelen bilgileri yakala
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddAsync(actor);

            return RedirectToAction(nameof(Index));

        }

        // 26
        // Get : Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails=await _service.GetByIdAsync(id);

            if (actorDetails == null) 
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        // 27
        // Get : Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        // 27
        // Post : Actors/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Index));
        }

        // 28
        // Get : Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);

        }

        //28
        // Post : Actors/Delete/1
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
