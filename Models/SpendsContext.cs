using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpendsDemo.Models
{
    public class SpendsContext : DbContext
    {
        public SpendsContext(DbContextOptions<SpendsContext> options)
		     : base(options)
			 {
				 
			 }
		
		public DbSet<SpendsDemo.Models.Spends> Spends {get; set;}
    }
}