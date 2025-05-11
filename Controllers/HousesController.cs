using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;
using RentalAppMVC.Services;
using RentalAppMVC.Services.Abstractions;
using RentalAppMVC.ViewModels;

namespace RentalAppMVC.Controllers
{
    public class HousesController : Controller
    {
        private readonly IHouseService _houseService;
        private readonly UserManager<User> _userManager;
     

        public HousesController(IHouseService houseService, UserManager<User> userManager)
        {
            _houseService = houseService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var items = await _houseService.GetAllAsync();
            return View(items);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var house = await _houseService.GetByIdAsync(id.Value);
            if (house == null) return NotFound();

            return View(house);
        }

 
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HouseDTO model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = _userManager.GetUserId(User);
                if (string.IsNullOrEmpty(model.UserId))
                {
                    ModelState.AddModelError("", "User ID is required. Please ensure you're logged in.");
                    ViewData["UserId"] = new SelectList(
                        _userManager.Users.Where(u => u.UserName != null), "Id", "UserName", model.UserId);
                    return View(model);
                }

                await _houseService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(
                _userManager.Users.Where(u => u.UserName != null), "Id", "UserName", model.UserId);

            return View(model);
        }

        public async Task<IActionResult> Landlord(string propertyId)
        {
            if (!int.TryParse(propertyId, out var id))
            {
                return BadRequest("Invalid property ID.");
            }


            var property = await _houseService.GetByIdAsync(id);
            if (property == null) return NotFound();

            var user = await _userManager.FindByIdAsync(property.UserId);
            if (user == null) return NotFound();

            var userDto = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                ContactInformation = user.ContactInformation,
                
            };
            var viewModel = new LandlordViewModel
            {
                Landlord = userDto,
                PropertyId = propertyId
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var house = await _houseService.GetByIdAsync(id.Value);
            if (house == null) return NotFound();

            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName", house.UserId);
            return View(house);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HouseDTO model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _houseService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName", model.UserId);
            return View(model);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var house = await _houseService.GetByIdAsync(id.Value);
            if (house == null) return NotFound();

            return View(house);
        }

 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _houseService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rent(string id)
        {
            if (!int.TryParse(id, out var studioId))
            {
                return BadRequest("Invalid property ID.");
            }

            var studio = await _houseService.GetByIdAsync(studioId);
            if (studio == null || !studio.IsAvailable)
            {
                return NotFound();
            }

            await _houseService.RentAsync(studioId);
            return RedirectToAction("Index", "Home");
        }
        private async Task<bool> HouseExistsAsync(int id)
        {
            return (await _houseService.GetByIdAsync(id)).Id == id;
        }
    }
}
    

