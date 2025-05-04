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
using RentalAppMVC.Services.Abstractions;

namespace RentalAppMVC.Controllers
{
    public class ApartmentsController : Controller
    {
        private IApartmentService _apartmentService;
        private UserManager<User> _userManager;
        public ApartmentsController(IApartmentService apartmentService, UserManager<User> userManager)
        {
            _apartmentService = apartmentService;
            _userManager = userManager;
        }

        // GET: Apartments
        public async Task<IActionResult> Index()
        {
            var items = await _apartmentService.GetAllAsync();
            return View(items);
        }

        // GET: Apartments/Details/5
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

        // GET: Apartments/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName");
            return View();
        }

        // POST: Apartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                await _apartmentService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userManager.Users, "Id", "UserName", model.UserId);
            return View(model);
        }

        // GET: Apartments/Edit/5
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

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Apartments/Delete/5
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

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _apartmentService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ApartmentExistsAsync(int id)
        {
            return (await _apartmentService.GetByIdAsync(id)).Id == id;
        }
    }
}
