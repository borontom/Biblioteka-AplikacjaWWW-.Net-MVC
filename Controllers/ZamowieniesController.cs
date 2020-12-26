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
    public class ZamowieniesController : Controller
    {
        private readonly dbbibliotekaContext _context;

        public ZamowieniesController(dbbibliotekaContext context)
        {
            _context = context;
        }

        // GET: Zamowienies
        public async Task<IActionResult> Index()
        {
            var dbbibliotekaContext = _context.Zamowienie.Include(z => z.Czytelnik).Include(z => z.Ksiazka);
            return View(await dbbibliotekaContext.ToListAsync());
        }

        // GET: Zamowienies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Czytelnik)
                .Include(z => z.Ksiazka)
                .FirstOrDefaultAsync(m => m.IdZamowienie == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // GET: Zamowienies/Create
        public IActionResult Create()
        {
            ViewData["CzytelnikId"] = new SelectList(_context.Czytelnik, "IdCzytelnik", "IdCzytelnik");
            ViewData["KsiazkaId"] = new SelectList(_context.Ksiazka, "IdKsiazka", "Tytul");
            return View();
        }

        // POST: Zamowienies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZamowienie,CzytelnikId,KsiazkaId,DataZamowienia")] Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CzytelnikId"] = new SelectList(_context.Czytelnik, "IdCzytelnik", "IdCzytelnik", zamowienie.CzytelnikId);
            ViewData["KsiazkaId"] = new SelectList(_context.Ksiazka, "IdKsiazka", "Tytul", zamowienie.KsiazkaId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie.FindAsync(id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            ViewData["CzytelnikId"] = new SelectList(_context.Czytelnik, "IdCzytelnik", "IdCzytelnik", zamowienie.CzytelnikId);
            ViewData["KsiazkaId"] = new SelectList(_context.Ksiazka, "IdKsiazka", "Tytul", zamowienie.KsiazkaId);
            return View(zamowienie);
        }

        // POST: Zamowienies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZamowienie,CzytelnikId,KsiazkaId,DataZamowienia")] Zamowienie zamowienie)
        {
            if (id != zamowienie.IdZamowienie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowienieExists(zamowienie.IdZamowienie))
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
            ViewData["CzytelnikId"] = new SelectList(_context.Czytelnik, "IdCzytelnik", "IdCzytelnik", zamowienie.CzytelnikId);
            ViewData["KsiazkaId"] = new SelectList(_context.Ksiazka, "IdKsiazka", "Tytul", zamowienie.KsiazkaId);
            return View(zamowienie);
        }

        // GET: Zamowienies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zamowienie = await _context.Zamowienie
                .Include(z => z.Czytelnik)
                .Include(z => z.Ksiazka)
                .FirstOrDefaultAsync(m => m.IdZamowienie == id);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return View(zamowienie);
        }

        // POST: Zamowienies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zamowienie = await _context.Zamowienie.FindAsync(id);
            _context.Zamowienie.Remove(zamowienie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowienieExists(int id)
        {
            return _context.Zamowienie.Any(e => e.IdZamowienie == id);
        }
    }
}
