using System;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using Microsoft.AspNetCore.Authorization;
using SpendsDemo.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Collections.Generic;


namespace SpendsDemo.Helpers
{
    public class DemoHelper : IDemoHelper
    {	
        public List<Spends> readExcelFile(IFormFile file, string path)
		{
			List<Spends> spList = new List<Spends>();
			Spends sp = new Spends();
			sp.Name = "Default";
			
			if(file == null || file.Length <= 0)
			{
				sp.Name = "Default-NoFile";
				spList.Add(sp);
				return spList;
			}
			if(file.Length > 0)
			{
				string ext = Path.GetExtension(file.FileName).ToLower();
				
				ISheet sheet;
				string fullPath = Path.Combine(path,file.FileName);
				
				using(var stream = new FileStream(fullPath,FileMode.Create))
				{
					file.CopyTo(stream);
					stream.Position = 0;
					if(ext == ".xls")
					{
						HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //old excel formats
						sheet = hssfwb.GetSheetAt(0);
					}
					else
					{
						XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //new formats
						sheet = hssfwb.GetSheetAt(0);
					}
					
					//Get the number of rows in the sheet so we can check if it's a valid spends data file
					IRow headerRow = sheet.GetRow(0); 
					int cellCount = headerRow.LastCellNum;
					
					if(cellCount != 16)
					{
						sp.Name = "Default-InvalidSpendsData";
						spList.Add(sp);
				        return spList;
					}
					for(int j = 0; j < cellCount; j++)
					{
						NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
						if(cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
						//sb.Append("<th>" + cell.ToString() + "</th>");
					}
					//sb.Append("</tr>");
					
					//sb.AppendLine("<tr>");
					
					//Read the file
					for(int i = (sheet.FirstRowNum + 1);i <= sheet.LastRowNum; i++)
					{
						sp = new Spends();
						IRow row = sheet.GetRow(i);
						if(row == null) continue;
						if(row.Cells.All(d => d.CellType == CellType.Blank)) continue;
			            
						//Transaction date = month + year
						sp.TransactionDate = DateTime.Parse(row.GetCell(0).ToString());
						
						//Date Added
						sp.DateAdded = DateTime.Now;
	
						
						for(int j = row.FirstCellNum; j < cellCount; j++)
						{
							//if(row.GetCell(j) != null) sb.Append("<td> " + row.GetCell(j).ToString() + "</td>");
							if(row.GetCell(j) != null)
							{
								string cellValue = row.GetCell(j).ToString();
								switch(j)
								{																
									case 1: //Media
									 sp.Media = cellValue;
									break;
									
									case 2: //Region
									 sp.Region = cellValue;
									break;
									
									case 3: //Quarter
									 sp.Quarter = cellValue;
									break;
									
									case 4: //Category
									 sp.Category = cellValue;
									break;
									
									case 5: //Advertizer
									 sp.Advertizer = cellValue;
									break;
									
									case 6: //Brand
									 sp.Brand = cellValue;
									break;
									
									case 7: //Station
									 sp.Station = cellValue;
									break;
									
									case 8: //TV/Radio
									 sp.TVRadio = Convert.ToInt32(cellValue);
									break;
									
									case 9: //Days
									 sp.Days = cellValue;
									break;
									
									case 10: //TimeBand
									 sp.TimeBand = cellValue;
									break;
									
									case 11:	//TimeSlot
									 sp.TimeSlot = cellValue;
									break;
									
									case 12: //Print
									 sp.Print = Convert.ToInt32(cellValue);
									break;
									
									case 13: //AverageDuration
									 sp.AverageDuration = Convert.ToInt32(cellValue);
									break;
									
									case 14: //AdSize
									 sp.AdSize = cellValue;
									break;
									
									case 15: //TotalSpend
									 sp.TotalSpend = cellValue;
									break;
								}
							} 
						}
						sp.Name = "Default-OK";
						spList.Add(sp);
					}
					
					
				}
			}
			
			return spList;
		}
		
		public string getRole(string email)
		{
			string ret = "NoRole";
		
			return ret;
		}
		
		public IQueryable<string>[] getQuery(SpendsContext sc, string x, string y, string ctype)
		{
			IQueryable<string>[] ret = new IQueryable<string>[2];
			
			/*
			Month,Media,Region,Quarter,Category,Advertizer,Brand,Station,TVRadio,Days,TimeBand,TimeSlot,Print,AverageDuration,AdSize,TotalSpend
			*/
			
		   //Get linq query for XVal
			switch(x)
			{
				case "date":
				  ret[0] = from c in sc.Spends
							select c.TransactionDate.ToString("Y");
				break;
				case "media":
				  ret[0] = from c in sc.Spends
							select c.Media;
				break;
				case "region":
				  ret[0] = from c in sc.Spends
							select c.Region;
				break;
				case "quarter":
				  ret[0] = from c in sc.Spends
							select c.Quarter;
				break;
				case "category":
				  ret[0] = from c in sc.Spends
							select c.Category;
				break;
				case "advertizer":
				  ret[0] = from c in sc.Spends
							select c.Advertizer;
				break;
				case "brand":
				  ret[0] = from c in sc.Spends
							select c.Brand;
				break;
				case "station":
				  ret[0] = from c in sc.Spends
							select c.Station;
				break;
				case "tvradio":
				  ret[0] = from c in sc.Spends
							select "" + c.TVRadio;
				break;
				case "days":
				  ret[0] = from c in sc.Spends
							select c.Days;
				break;
				case "timeband":
				  ret[0] = from c in sc.Spends
							select c.TimeBand;
				break;
				case "timeslot":
				  ret[0] = from c in sc.Spends
							select c.TimeSlot;
				break;
				case "print":
				  ret[0] = from c in sc.Spends
							select "" + c.Print;
				break;
				case "duration":
				  ret[0] = from c in sc.Spends
							select "" +  c.AverageDuration;
				break;
				case "adsize":
				  ret[0] = from c in sc.Spends
							select c.AdSize;
				break;
				
				default:
				  ret[0] = from c in sc.Spends
							select c.TransactionDate.ToString("Y");
				break;
			}
			
			//Get linq query for YVal
			switch(y)
			{
				case "media":
				  ret[1] = from c in sc.Spends
							select c.Media;
				break;
				case "region":
				  ret[1] = from c in sc.Spends
							select c.Region;
				break;
				case "quarter":
				  ret[1] = from c in sc.Spends
							select c.Quarter;
				break;
				case "category":
				  ret[1] = from c in sc.Spends
							select c.Category;
				break;
				case "advertizer":
				  ret[1] = from c in sc.Spends
							select c.Advertizer;
				break;
				case "brand":
				  ret[1] = from c in sc.Spends
							select c.Brand;
				break;
				case "station":
				  ret[1] = from c in sc.Spends
							select c.Station;
				break;
				case "tvradio":
				  ret[1] = from c in sc.Spends
							select "" + c.TVRadio;
				break;
				case "days":
				  ret[1] = from c in sc.Spends
							select c.Days;
				break;
				case "timeband":
				  ret[1] = from c in sc.Spends
							select c.TimeBand;
				break;
				case "timeslot":
				  ret[1] = from c in sc.Spends
							select c.TimeSlot;
				break;
				case "print":
				  ret[1] = from c in sc.Spends
							select "" + c.Print;
				break;
				case "duration":
				  ret[1] = from c in sc.Spends
							select "" + c.AverageDuration;
				break;
				case "adsize":
				  ret[1] = from c in sc.Spends
							select c.AdSize;
				break;
				/*case "spend":
				case "totalspend":
				  ret[1] = from c in sc.Spends
				           group c by c.TransactionDate into g
							select new
							{
								TransactionDate = g.Key,
								TotalSpend g.Sum(xx => xx.TotalSpend)
							};
				break;
				*/
				default:
				  ret[1] = from c in sc.Spends
							select c.TotalSpend;
				break;
			}
							
			return ret;
		}
		
		public List<SpendSums> getSpendSums(SpendsContext sc, string filter)
		{
			//var ret = new List<dynamic>();
			List<SpendSums> ss = new List<SpendSums>();
			SpendSums sss = new SpendSums();
			
			//Media,Region,Quarter,Category,Advertizer,Brand,Station,TVRadio,Days,TimeBand,TimeSlot,Print,AverageDuration,AdSize,TotalSpend
			
			switch(filter)
			{
				case "date":
				   var DateQuery = from c in sc.Spends
				               group c by c.TransactionDate into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
							   
				var DateRet = DateQuery.ToList();
				
			    foreach(var r in DateRet)
			    {
				   ss.Add(new SpendSums{
					       PKey = r.PKey.ToString("Y"),
                           TSpend = r.TSpend						   
					 });
			    }
				break;
				
				case "brand":
				   var BrandQuery = from c in sc.Spends
				               group c by c.Brand into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var BrandRet = BrandQuery.ToList();

	     		    foreach(var r in BrandRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;

				case "media":
				   var mediaQuery = from c in sc.Spends
				               group c by c.Media into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var mediaRet = mediaQuery.ToList();

	     		    foreach(var r in mediaRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;

				case "region":
				   var RegionQuery = from c in sc.Spends
				               group c by c.Region into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var RegionRet = RegionQuery.ToList();

	     		    foreach(var r in RegionRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;

				case "quarter":
				   var QuarterQuery = from c in sc.Spends
				               group c by c.Quarter into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var QuarterRet = QuarterQuery.ToList();

	     		    foreach(var r in QuarterRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;	
				
				case "category":
				   var CategoryQuery = from c in sc.Spends
				               group c by c.Category into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var CategoryRet = CategoryQuery.ToList();

	     		    foreach(var r in CategoryRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
				case "advertizer":
				   var AdvertizerQuery = from c in sc.Spends
				               group c by c.Advertizer into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var AdvertizerRet = AdvertizerQuery.ToList();

	     		    foreach(var r in AdvertizerRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
				case "station":
				   var StationQuery = from c in sc.Spends
				               group c by c.Station into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var StationRet = StationQuery.ToList();

	     		    foreach(var r in StationRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
	
				case "days":
				   var DaysQuery = from c in sc.Spends
				               group c by c.Days into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var DaysRet = DaysQuery.ToList();

	     		    foreach(var r in DaysRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
				case "timeband":
				   var TimeBandQuery = from c in sc.Spends
				               group c by c.TimeBand into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var TimeBandRet = TimeBandQuery.ToList();

	     		    foreach(var r in TimeBandRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
				case "timeslot":
				   var TimeSlotQuery = from c in sc.Spends
				               group c by c.TimeSlot into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Sum(sp => Convert.ToInt64(sp.TotalSpend))							 
						       };
    				var TimeSlotRet = TimeSlotQuery.ToList();

	     		    foreach(var r in TimeSlotRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
			}
			
			return ss;
		}
		
		public List<SpendSums> getTotals(SpendsContext sc, string filter)
		{
			List<SpendSums> ss = new List<SpendSums>();
			
			//Media,Region,Quarter,Category,Advertizer,Brand,Station,TVRadio,Days,TimeBand,TimeSlot,Print,AverageDuration,AdSize,TotalSpend
			
			switch(filter)
			{
				case "date":
				   var DateQuery = from c in sc.Spends
				               group c by c.TransactionDate into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
							   
				var DateRet = DateQuery.ToList();
				
			    foreach(var r in DateRet)
			    {
				   ss.Add(new SpendSums{
					       PKey = r.PKey.ToString("Y"),
                           TSpend = r.TSpend						   
					 });
			    }
				break;
				
				case "brand":
				   var BrandQuery = from c in sc.Spends
				               group c by c.Brand into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var BrandRet = BrandQuery.ToList();

	     		    foreach(var r in BrandRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;

				case "media":
				   var mediaQuery = from c in sc.Spends
				               group c by c.Media into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var mediaRet = mediaQuery.ToList();

	     		    foreach(var r in mediaRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;

				case "region":
				   var RegionQuery = from c in sc.Spends
				               group c by c.Region into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var RegionRet = RegionQuery.ToList();

	     		    foreach(var r in RegionRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;

				case "quarter":
				   var QuarterQuery = from c in sc.Spends
				               group c by c.Quarter into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var QuarterRet = QuarterQuery.ToList();

	     		    foreach(var r in QuarterRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;	
				
				case "category":
				   var CategoryQuery = from c in sc.Spends
				               group c by c.Category into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var CategoryRet = CategoryQuery.ToList();

	     		    foreach(var r in CategoryRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
				case "advertizer":
				   var AdvertizerQuery = from c in sc.Spends
				               group c by c.Advertizer into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var AdvertizerRet = AdvertizerQuery.ToList();

	     		    foreach(var r in AdvertizerRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
				case "station":
				   var StationQuery = from c in sc.Spends
				               group c by c.Station into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var StationRet = StationQuery.ToList();

	     		    foreach(var r in StationRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
	
				case "days":
				   var DaysQuery = from c in sc.Spends
				               group c by c.Days into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var DaysRet = DaysQuery.ToList();

	     		    foreach(var r in DaysRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
				case "timeband":
				   var TimeBandQuery = from c in sc.Spends
				               group c by c.TimeBand into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var TimeBandRet = TimeBandQuery.ToList();

	     		    foreach(var r in TimeBandRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
				case "timeslot":
				   var TimeSlotQuery = from c in sc.Spends
				               group c by c.TimeSlot into g
						       select new{
							     PKey = g.Key,
                                 TSpend = g.Count()							 
						       };
    				var TimeSlotRet = TimeSlotQuery.ToList();

	     		    foreach(var r in TimeSlotRet)
		     	    {
			    	   ss.Add(new SpendSums{
				    	       PKey = r.PKey,
                               TSpend = r.TSpend						   
					     });
			        }
				break;
				
			}
			
			return ss;
		}
    }
}