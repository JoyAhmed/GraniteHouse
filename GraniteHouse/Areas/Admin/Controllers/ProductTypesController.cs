using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ProductTypes.ToList());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.ProductTypes.FindAsync(id);

            if(productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        //POST Edit action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductTypes productTypes)
        {
            if (id!=productTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(productTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _context.ProductTypes.FindAsync(id);

            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        //POST Details action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, ProductTypes productTypes)
        {
            if (id != productTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(productTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }
    }
}