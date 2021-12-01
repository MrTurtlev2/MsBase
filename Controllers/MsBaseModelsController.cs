using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MsBase.Data;
using MsBase.Models;

namespace MsBase.Controllers
{
    public class MsBaseModelsController : Controller
    {
        private readonly MsBaseContext _context;

        public MsBaseModelsController(MsBaseContext context)
        {
            _context = context;
        }

        // GET: MsBaseModels
        public async Task<IActionResult> Index(string searchString)
        {

         
                //LINQ - query syntax
                var movies = from m in _context.MsBaseModel
                             select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    //LINQ - method based syntax
                    movies = movies.Where(s => s.Name.Contains(searchString)); //Lambda Expression
                }

                return View(await movies.ToListAsync()); //execution is deferred till this line
           



            // return View(await _context.MsBaseModel.ToListAsync());
        }

        // GET: MsBaseModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msBaseModel = await _context.MsBaseModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (msBaseModel == null)
            {
                return NotFound();
            }

            return View(msBaseModel);
        }

        // GET: MsBaseModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MsBaseModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country,Avilable,Price")] MsBaseModel msBaseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(msBaseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(msBaseModel);
        }

        // GET: MsBaseModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msBaseModel = await _context.MsBaseModel.FindAsync(id);
            if (msBaseModel == null)
            {
                return NotFound();
            }
            return View(msBaseModel);
        }

        // POST: MsBaseModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country,Avilable,Price")] MsBaseModel msBaseModel)
        {
            if (id != msBaseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(msBaseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MsBaseModelExists(msBaseModel.Id))
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
            return View(msBaseModel);
        }

        // GET: MsBaseModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msBaseModel = await _context.MsBaseModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (msBaseModel == null)
            {
                return NotFound();
            }

            return View(msBaseModel);
        }

        // POST: MsBaseModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var msBaseModel = await _context.MsBaseModel.FindAsync(id);
            _context.MsBaseModel.Remove(msBaseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MsBaseModelExists(int id)
        {
            return _context.MsBaseModel.Any(e => e.Id == id);
        }
    }
}
