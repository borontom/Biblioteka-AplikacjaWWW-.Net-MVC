using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using biblioteka___nowy_projekt.Models;

namespace biblioteka___nowy_projekt.Controllers
{
    public class CzytelniksController : Controller
    {
        private readonly dbbibliotekaContext _context;

        public CzytelniksController(dbbibliotekaContext context)
        {
            _context = context;
        }

        // GET: Czytelniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Czytelnik.ToListAsync());
        }

        // GET: Czytelniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czytelnik = await _context.Czytelnik
                .FirstOrDefaultAsync(m => m.IdCzytelnik == id);
            if (czytelnik == null)
            {
                return NotFound();
            }

            return View(czytelnik);
        }

        // GET: Czytelniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Czytelniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCzytelnik,Imie,Nazwisko,Miasto,Telefon")] Czytelnik czytelnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(czytelnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(czytelnik);
        }

        // GET: Czytelniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czytelnik = await _context.Czytelnik.FindAsync(id);
            if (czytelnik == null)
            {
                return NotFound();
            }
            return View(czytelnik);
        }

        // POST: Czytelniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCzytelnik,Imie,Nazwisko,Miasto,Telefon")] Czytelnik czytelnik)
        {
            if (id != czytelnik.IdCzytelnik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(czytelnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CzytelnikExists(czytelnik.IdCzytelnik))
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
            return View(czytelnik);
        }

        // GET: Czytelniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var czytelnik = await _context.Czytelnik
                .FirstOrDefaultAsync(m => m.IdCzytelnik == id);
            if (czytelnik == null)
            {
                return NotFound();
            }

            return View(czytelnik);
        }

        // POST: Czytelniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var czytelnik = await _context.Czytelnik.FindAsync(id);
            _context.Czytelnik.Remove(czytelnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CzytelnikExists(int id)
        {
            return _context.Czytelnik.Any(e => e.IdCzytelnik == id);
        }
    }
}
