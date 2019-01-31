using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SpendsDemo.Models
{
    public class SpendComparisons
    {
        public string XKey {get; set;}
        public string YKey {get; set;}
        public long TCount {get; set;}
    }
}