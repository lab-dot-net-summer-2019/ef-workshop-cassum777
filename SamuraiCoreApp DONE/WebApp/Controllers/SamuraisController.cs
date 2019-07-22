using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace WebApp.Controllers
{

    public class SamuraisController : Controller
    {
        private readonly SamuraiContext _context;

        public SamuraisController(SamuraiContext context) =>
            _context = context;

        // GET: Samurais
        public async Task<IActionResult> Index() =>
            View(await _context.Samurai.ToListAsync());

        // GET: Samurais/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                NotFound();
            //TODO
            //Get single Samurai, including quotes and SecretIdentity with id = id (query param)
            var samurai = await _context.Samurai.FindAsync(id);
            return samurai != null ? (IActionResult)View(samurai) : NotFound();
        }

        // GET: Samurais/Create
        [AllowAnonymous]
        [ActionName("Create")]
        public IActionResult Create() => 
            View();


        // POST: Samurais/Create
        //http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> Create([Bind("Id,Name")] Samurai samurai)
        {
            if (ModelState.IsValid)
            {
                //TODO
                //Add samurai
                _context.Samurai.Add(samurai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(samurai);
        }

        // GET: Samurais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            //TODO
            //Get single Samurai with quotes and SecretIdentity with id = id (query param)
            var samurai = await _context.Samurai.FindAsync(id);
            return  samurai != null ? (IActionResult)View(samurai) : NotFound();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Samurai samurai)
        public async Task<IActionResult> Edit(int id, Samurai samurai)
        {
            if (id != samurai.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    //TODO
                    //Update samurai
                    var secretIdentity = _context.SecretIdentities.FirstOrDefault(x => x.SamuraiId == samurai.Id);
                    if (secretIdentity == null)
                        _context.Add(samurai.SecretIdentity);
                    else
                        secretIdentity.RealName = samurai.SecretIdentity.RealName;
                    var samuraiDb = _context.Samurai.Find(id);
                    samuraiDb.Name = samurai.Name;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamuraiExists(samurai.Id))
                        return NotFound();
                    else
                        await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(samurai);
        }

        // GET: Samurais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            //TODO
            //Get single Samurai with id = id (query param)
            var samurai = await _context.Samurai.FindAsync(id);
            return samurai == null ? NotFound() : (IActionResult)View(samurai);
        }

        // POST: Samurais/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //TODO
            //Get single Samurai with id = id (query param)
            //and remove
            var samyrai = _context.Samurai.Find(id);
            _context.Remove(samyrai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamuraiExists(int id) =>
            _context.Samurai.Any(e => e.Id == id);

    }
}