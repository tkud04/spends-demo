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
using Microsoft.AspNetCore.Identity;


namespace SpendsDemo.Controllers
{
    public class UploadsController : Controller
    {
        private readonly UploadsContext _context;
        private readonly SpendsContext _sc;
        private readonly IDemoHelper _h;
        private readonly IHostingEnvironment _e;
        private readonly UserManager<IdentityUser> _um;
		
        public UploadsController(UserManager<IdentityUser> userManager, UploadsContext context, SpendsContext spendsContext,IDemoHelper helper, IHostingEnvironment env)
        {
            _context = context;
            _sc = spendsContext;
			_h = helper;
			_e = env;
			_um = userManager;
        }

        // GET: Uploads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uploads.ToListAsync());
        }
		
		// GET: Spends/Test
        public IActionResult Test()
        {
            return View();
        }
		
		// POST: Spends/Test
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Test")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TestUpload(IFormFile ff)
        {
            // = Request.Files[0];
			string path = Path.Combine(_e.WebRootPath,"Uploads");		
			
			if(!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			
			List<Spends> spList = _h.readExcelFile(ff,path);
			string sb = "";
			
			if(spList.Count == 1 && spList[0].Name != "Default-OK")
			{
			   if(spList[0].Name == "Default")
			   {
				  sb = "<span class='text-danger'>An unknown problem has occured.</span>";
			   }
			   else if(spList[0].Name == "Default-NoFile")
			   {
				  sb = "<span class='text-danger'>File not sent to server</span>";
			   }
			   else if(spList[0].Name == "Default-InvalidSpendsData")
			   {
				  sb = "<span class='text-danger'>Invalid spends data. Please upload an Excel file with valid Spends data</span>";
			   }
			}
			else
			{
				var user = await _um.GetUserAsync(HttpContext.User);
				
				//Add data to Uploads
				Uploads uploadEntry = new Uploads();
				uploadEntry.Fname =  path;
			    uploadEntry.UploadedBy = user.UserName;
				
				_context.Add(uploadEntry);
                await _context.SaveChangesAsync();
				
				foreach(Spends sp in spList)
				{
				   sp.Name = user.UserName;
				
				   //Add data to Spends
				   _sc.Add(sp);
                   await _sc.SaveChangesAsync();
				}
				
				sb = "<span class='text-success'>Data upload successful!</span>";
			}
			
			return this.Content(sb);
			//return View();
        }

        // GET: Uploads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploads = await _context.Uploads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uploads == null)
            {
                return NotFound();
            }

            return View(uploads);
        }

        // GET: Uploads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uploads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fname,UploadedBy,dateUploaded")] Uploads uploads)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uploads);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uploads);
        }

        // GET: Uploads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploads = await _context.Uploads.FindAsync(id);
            if (uploads == null)
            {
                return NotFound();
            }
            return View(uploads);
        }

        // POST: Uploads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Fname,UploadedBy,dateUploaded")] Uploads uploads)
        {
            if (id != uploads.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uploads);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UploadsExists(uploads.Id))
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
            return View(uploads);
        }

        // GET: Uploads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uploads = await _context.Uploads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uploads == null)
            {
                return NotFound();
            }

            return View(uploads);
        }

        // POST: Uploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var uploads = await _context.Uploads.FindAsync(id);
            _context.Uploads.Remove(uploads);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UploadsExists(string id)
        {
            return _context.Uploads.Any(e => e.Id == id);
        }
    }
}
