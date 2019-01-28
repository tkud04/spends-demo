using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SpendsDemo.Models
{
    public class SpendsCategoryViewModel
    {
        public List<Spends> Spends;
        public List<string> Months;
        public List<string> XVals;
        public List<string> YVals;
        public string SearchString{ get; set; }
        public string ErrorString{ get; set; }
        public string CType{ get; set; }
    }
}