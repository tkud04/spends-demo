using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using SpendsDemo.Models;
using SpendsDemo.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SpendsDemo.Controllers
{
    public class HomeController : Controller
    {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IDemoHelper _h;
		private readonly SpendsContext _sc;
		
		public HomeController(UserManager<IdentityUser> um, RoleManager<IdentityRole> rm, IDemoHelper helper, SpendsContext spendsContext)
		{
			_userManager = um;
			_roleManager = rm;
			_h = helper;
			_sc = spendsContext;
		}
		
		[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
			var user = await _userManager.GetUserAsync(HttpContext.User);
			//var role = _h.getRole(_userManager,user.Email); 
			//ViewData["roles"] = roles; 
			
			IQueryable<Spends> sp = from m in _sc.Spends
							  select m;
							  
			IQueryable<string> monthQuery = from m in _sc.Spends
							  select m.Month;
            
						  
			//List<Spends> spendsList = await yearlySalesQuery.ToListAsync();
			
			var spendsCategoryVM = new SpendsCategoryViewModel
			{
				Spends = await sp.ToListAsync(),
				Months = await monthQuery.Distinct().ToListAsync(),
			};
            return View(spendsCategoryVM);
        }
		
        // GET: Spends/LinqTest
        public async Task<IActionResult> LinqTest(string x, string y, string ctype)
        {
			string errorString = "";
			
            if (x == null || y == null || ctype == null)
            {
				errorString = "Invalid number of query requirements";
            }
			
			IQueryable<string>[] queries = _h.getQuery(_sc,x,y,ctype);
			
            var spendsCategoryVM = new SpendsCategoryViewModel{
				ErrorString= errorString,
				XVals = await queries[0].ToListAsync(),
				YVals = await queries[1].ToListAsync(),
				CType = ctype
			};
			
            return View(spendsCategoryVM);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
