using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalAppMVC.Data;
using RentalAppMVC.DTOs;
using RentalAppMVC.Services;
using RentalAppMVC.Services.Abstractions;
using RentalAppMVC.ViewModels;

namespace RentalAppMVC.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private UserManager<User> _userManager;
        public ApartmentsController(IApartmentService apartmentService, UserManager<User> userManager)
        {
            _apartmentService = apartmentService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var items = await _apartmentService.GetAllAsync();
            return View(items);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _apartmentService.GetByIdAsync(id.Value);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }


        public IActionResult Create()
        
       {
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }
        public async Task<IActionResult> Landlord(string propertyId)
        {
            if (!int.TryParse(propertyId, out var id))
            {
                return BadRequest("Invalid property ID.");
            }

            
            var property = await _apartmentService.GetByIdAsync(id);
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApartmentDTO model)
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
                await _apartmentService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_userManager.Users.Where(u => u.UserName != null), "Id", "UserName", model.UserId);
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _apartmentService.GetByIdAsync(id.Value);
            if (apartment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName", apartment.UserId);
            return View(apartment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApartmentDTO model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _apartmentService.UpdateAsync(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ApartmentExistsAsync(model.Id))
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
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName", model.UserId);
            return View(model);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _apartmentService.GetByIdAsync(id.Value);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _apartmentService.DeleteByIdAsync(id);
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

            var studio = await _apartmentService.GetByIdAsync(studioId);
            if (studio == null || !studio.IsAvailable)
            {
                return NotFound();
            }

            await _apartmentService.RentAsync(studioId);
            return RedirectToAction("Index", "Home");
        }
        private async Task<bool> ApartmentExistsAsync(int id)
        {
            return (await _apartmentService.GetByIdAsync(id)).Id == id;
        }
    }
}