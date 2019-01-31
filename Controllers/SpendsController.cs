using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpendsDemo.Models;
using SpendsDemo.Helpers;
using System.Text;
using System.IO;

namespace SpendsDemo.Controllers
{
    public class SpendsController : Controller
    {
        private readonly SpendsContext _context;
        private readonly IDemoHelper _h;
        private readonly IHostingEnvironment _e;

        public SpendsController(SpendsContext context,IDemoHelper helper, IHostingEnvironment env)
        {
            _context = context;
			_h = helper;
			_e = env;
        }

        // GET: Spends
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spends.ToListAsync());
        }

        // GET: Spends/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spends = await _context.Spends
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spends == null)
            {
                return NotFound();
            }

            return View(spends);
        }
		

        // GET: Spends/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Media,Region,Quarter,Category,Advertizer,Brand,Station,TVRadio,Days,TransactionDate,TimeBand,TimeSlot,Print,AverageDuration,AdSize,TotalSpend,DateAdded")] Spends spends)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spends);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spends);
        }

        // GET: Spends/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spends = await _context.Spends.FindAsync(id);
            if (spends == null)
            {
                return NotFound();
            }
            return View(spends);
        }

        // POST: Spends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Media,Region,Quarter,Category,Advertizer,Brand,Station,TVRadio,Days,TransactionDate,TimeBand,TimeSlot,Print,AverageDuration,AdSize,TotalSpend,DateAdded")] Spends spends)
        {
            if (id != spends.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spends);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpendsExists(spends.Id))
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
            return View(spends);
        }

        // GET: Spends/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spends = await _context.Spends
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spends == null)
            {
                return NotFound();
            }

            return View(spends);
        }

        // POST: Spends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var spends = await _context.Spends.FindAsync(id);
            _context.Spends.Remove(spends);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpendsExists(string id)
        {
            return _context.Spends.Any(e => e.Id == id);
        }
    }
}
