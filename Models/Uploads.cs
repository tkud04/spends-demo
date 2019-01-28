using System;
using System.ComponentModel.DataAnnotations;

namespace SpendsDemo.Models
{
    public class Uploads
    {
        public string Id { get; set; }
        
		[Required]
		public string Fname { get; set; }
		
		[Required]
		[Display(Name = "Uploaded by")]
		public string UploadedBy { get; set; }
		
		[Display(Name = "Date Uploaded")]
		[DataType(DataType.Date)]
        public DateTime dateUploaded{ get; set; }
    }
}