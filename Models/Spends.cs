using System;
using System.ComponentModel.DataAnnotations;

namespace SpendsDemo.Models
{
    public class Spends
    {
        public string Id { get; set; }
        
		[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
		[Required]
		public string Name { get; set; }
		
		[Required]
		public string Month { get; set; }
		
		[Required]
		public string Media { get; set; }
		
		[Required]
		public string Region { get; set; }
		
		[Required]
		public string Quarter { get; set; }
		
		[Required]
		public string Category { get; set; }
		
		[Required]
		public string Advertizer { get; set; }
	    
		[Required]
		public string Brand { get; set; }
	    
		[Required]
		public string Station { get; set; }
		
		[Required]
		[Display(Name = "TV/Radio")]
		public int TVRadio { get; set; }
		
		[Required]
		public string Days { get; set; }
		
		[Display(Name = "Time Band")]
		public string TimeBand { get; set; }
		
		[Display(Name = "Time Slot")]
		public string TimeSlot { get; set; }
		
		[Required]
		[Display(Name = "Print/OOH")]
		public int Print { get; set; }
		
		[Required]
		[Display(Name = "Avg. Duration")]
		public int AverageDuration { get; set; }
		
		[Display(Name = "Ad Size")]
		public string AdSize { get; set; }
		
		[Required]
		[Display(Name = "Total Spend")]
		[DataType(DataType.Currency)]
		public string TotalSpend { get; set; }
        
		[Display(Name = "Date Added")]
		[DataType(DataType.Date)]
        public DateTime dateAdded{ get; set; }
    }
}