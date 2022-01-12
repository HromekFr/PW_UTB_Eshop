using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entity;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RatingsController : Controller
    {
        private readonly EshopDbContext eshopDbContext;

        public RatingsController(EshopDbContext context)
        {
            eshopDbContext = context;
        }

        // GET: Admin/Ratings
        public async Task<IActionResult> Index()
        {
            return View(await eshopDbContext.Ratings.ToListAsync());
        }

        // GET: Admin/Ratings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await eshopDbContext.Ratings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Admin/Ratings/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(eshopDbContext.Products, "ID", "Name");
            return View();
        }

        // POST: Admin/Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductID,UserID,DateTimeCreated,Stars,Comment,IsVisible")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                eshopDbContext.Add(rating);
                await eshopDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Admin/Ratings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await eshopDbContext.Ratings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }

        // POST: Admin/Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductID,UserID,DateTimeCreated,Stars,Comment,IsVisible")] Rating rating)
        {
            if (id != rating.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    eshopDbContext.Update(rating);
                    await eshopDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.ID))
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
            return View(rating);
        }

        // GET: Admin/Ratings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await eshopDbContext.Ratings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Admin/Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rating = await eshopDbContext.Ratings.FindAsync(id);
            eshopDbContext.Ratings.Remove(rating);
            await eshopDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(int id)
        {
            return eshopDbContext.Ratings.Any(e => e.ID == id);
        }
    }
}
