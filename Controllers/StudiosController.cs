using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;
using RentalAppMVC.Services.Abstractions;


namespace RentalAppMVC.Controllers
{
    public class StudiosController : Controller
    {
        private IStudioService _studioService;
        private UserManager<User> _userManager;

        public StudiosController(IStudioService studioService, UserManager<User> userManager)
        {
            _studioService = studioService;
            _userManager = userManager;
        }

        // Get studios
        public async Task<IActionResult> Index()
        { 
        var items = await _studioService.GetAllAsync();
            return View(items);
        }

        // GET: Studios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studio = await _studioService.GetByIdAsync(id.Value);
            if (studio == null)
            {
                return NotFound();
            }
            return View(studio);
        }
        // GET: Studios/Create

        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }

        // POST: Studios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudioDTO model)
        {
            if (!ModelState.IsValid)
            {
                await _studioService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName", model.UserId);
            return View(model);

        }
        //Get Studios/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studio = await _studioService.GetByIdAsync(id.Value);
            if (studio == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id","UserName",studio.UserId);
            return View(studio);
        }

        //Post studio
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudioDTO model)
        {
            if (id != model.Id)
            {
                return NotFound();

            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _studioService.UpdateAsync(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StudioExistsAsync(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    { 
                    throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] =  new SelectList(_userManager.Users,"Id","UserName",model.UserId);
            return View(model);

        }
        //Get Studio/delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studio = await _studioService.GetByIdAsync(id.Value);
            if (studio == null)
            {
                return NotFound();
            }
            return View(studio);
        }

        //Post studio/ delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _studioService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rent(int id)
        {
            var studio = await _studioService.GetByIdAsync(id);
            if (studio == null || !studio.IsAvailable)
            {
                return NotFound();
            }

            await _studioService.RentAsync(id);
            return RedirectToAction("Index", "Home");
        }
        private async Task<bool> StudioExistsAsync(int id)
        {
            return (await _studioService.GetByIdAsync(id)).Id == id;
        }
    }
}
