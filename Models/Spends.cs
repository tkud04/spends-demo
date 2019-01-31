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
		[Display(Name = "Days")]
		public string Days { get; set; }
		
		[Display(Name = "Date")]
		[DataType(DataType.Date)]
        public DateTime TransactionDate{ get; set; }
		
		[Display(Name = "Time Band")]
		[DataType(DataType.Time)]
		public string TimeBand { get; set; }
		
		[Display(Name = "Time Slot")]
		[DataType(DataType.Time)]
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
        
		[Display(Name = "Upload Date")]
		[DataType(DataType.Date)]
        public DateTime DateAdded{ get; set; }
    }
}