using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpendsDemo.Models
{
    public class UploadsContext : DbContext
    {
        public UploadsContext(DbContextOptions<UploadsContext> options)
		     : base(options)
			 {
				 
			 }
		
		public DbSet<SpendsDemo.Models.Uploads> Uploads {get; set;}
    }
}