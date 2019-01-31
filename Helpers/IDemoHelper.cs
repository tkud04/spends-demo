using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SpendsDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpendsDemo.Helpers
{
    public interface IDemoHelper
    {
        List<Spends> readExcelFile(IFormFile file, string path);
		string getRole(string email);
		IQueryable<string>[] getQuery(SpendsContext sc, string x, string y, string ctype);
		List<SpendSums> getSpendSums(SpendsContext sc, string filter);
		List<SpendSums> getTotals(SpendsContext sc, string filter);
    }
}