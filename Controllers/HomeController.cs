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
							  select m.TransactionDate.ToString("m-Y");
            
						  
			//List<Spends> spendsList = await yearlySalesQuery.ToListAsync();
			
			var spendsCategoryVM = new SpendsCategoryViewModel
			{
				Spends = await sp.ToListAsync(),
				Months = await monthQuery.Distinct().ToListAsync(),
			};
            return View(spendsCategoryVM);
        }
		
        // GET: Home/LinqTest
        
		public async Task<IActionResult> LinqTest(string x, string y, string qtype, string ctype)
        {
			string errorString = "no errors here";
			errorString = "";
			
			var spendsCategoryVM = new SpendsCategoryViewModel();
			
            if (x == null || y == null || qtype == null || ctype == null)
            {
				errorString = "Invalid number of query requirements";
            }
			else
			{
			    if(qtype == "total")
				{
					var totals = _h.getTotals(_sc,x);
					spendsCategoryVM.SpendSums = totals;
				    spendsCategoryVM.XVals = new List<string>();
				    spendsCategoryVM.YVals = new List<string>();
				}
				
				else if(qtype == "comparison")
				{
			       if(y == "totalspend" || y == "spend")
			       {
				      var ss = _h.getSpendSums(_sc,x);
				      spendsCategoryVM.SpendSums = ss;
				      spendsCategoryVM.XVals = new List<string>();
				      spendsCategoryVM.YVals = new List<string>();
			       }
			       else
			       {
				      spendsCategoryVM.SpendSums = new List<SpendSums>();
			          IQueryable<string>[] queries = _h.getQuery(_sc,x,y,ctype);
				      spendsCategoryVM.XVals = await queries[0].ToListAsync();
				      spendsCategoryVM.YVals = await queries[1].ToListAsync();
			       }
				}
			}
			
			spendsCategoryVM.ErrorString = errorString;
			spendsCategoryVM.CType = ctype;
			
            return View(spendsCategoryVM);
        }
		
		// GET: Home/gb
        public async Task<IActionResult> GB()
        {
			string errorString = "";
				
			
			var query = from c in _sc.Spends
				           group c by new {c.Advertizer, c.Media} into g
						   select new{
							 XKey = g.Key.Advertizer,
							 YKey = g.Key.Media,
                             TCount = g.Count()							 
						   }; 
			
        	var ret = await query.ToListAsync();
			List<SpendComparisons> sc = new List<SpendComparisons>();
			
			foreach(var r in ret)
			{
				sc.Add(new SpendComparisons{
					       XKey = r.XKey.ToString(),
					       YKey = r.YKey.ToString(),
                           TCount = r.TCount						   
					 });
			}
			
            return View(sc);
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
