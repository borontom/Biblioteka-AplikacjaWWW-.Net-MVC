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
    public class KsiazkasController : Controller
    {
        private readonly dbbibliotekaContext _context;

        public KsiazkasController(dbbibliotekaContext context)
        {
            _context = context;
        }

        // GET: Ksiazkas
        public async Task<IActionResult> Index()
        {
            var dbbibliotekaContext = _context.Ksiazka.Include(k => k.Kategorie);
            return View(await dbbibliotekaContext.ToListAsync());
        }

        // GET: Ksiazkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazka
                .Include(k => k.Kategorie)
                .FirstOrDefaultAsync(m => m.IdKsiazka == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // GET: Ksiazkas/Create
        public IActionResult Create()
        {
            ViewData["KategorieId"] = new SelectList(_context.Kategoria, "IdKategoria", "Nazwa");
            return View();
        }

        // POST: Ksiazkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKsiazka,Tytul,Autor,Wydawnictwo,RokWydania,KategorieId")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ksiazka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorieId"] = new SelectList(_context.Kategoria, "IdKategoria", "Nazwa", ksiazka.KategorieId);
            return View(ksiazka);
        }

        // GET: Ksiazkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazka.FindAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            ViewData["KategorieId"] = new SelectList(_context.Kategoria, "IdKategoria", "Nazwa", ksiazka.KategorieId);
            return View(ksiazka);
        }

        // POST: Ksiazkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKsiazka,Tytul,Autor,Wydawnictwo,RokWydania,KategorieId")] Ksiazka ksiazka)
        {
            if (id != ksiazka.IdKsiazka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ksiazka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KsiazkaExists(ksiazka.IdKsiazka))
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
            ViewData["KategorieId"] = new SelectList(_context.Kategoria, "IdKategoria", "Nazwa", ksiazka.KategorieId);
            return View(ksiazka);
        }

        // GET: Ksiazkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazka
                .Include(k => k.Kategorie)
                .FirstOrDefaultAsync(m => m.IdKsiazka == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // POST: Ksiazkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ksiazka = await _context.Ksiazka.FindAsync(id);
            _context.Ksiazka.Remove(ksiazka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KsiazkaExists(int id)
        {
            return _context.Ksiazka.Any(e => e.IdKsiazka == id);
        }
    }
}
