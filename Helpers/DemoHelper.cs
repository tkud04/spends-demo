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
					
					IRow headerRow = sheet.GetRow(0); 
					int cellCount = headerRow.LastCellNum;
					//sb.Append("<table class='table'><tr>");
					
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
			            
						
						for(int j = row.FirstCellNum; j < cellCount; j++)
						{
							//if(row.GetCell(j) != null) sb.Append("<td> " + row.GetCell(j).ToString() + "</td>");
							if(row.GetCell(j) != null)
							{
								string cellValue = row.GetCell(j).ToString();
								switch(j)
								{
									case 0: //Month
									 sp.Month = cellValue;
									break;
									
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
									
									case 11: //TimeSlot
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
				case "month":
				  ret[0] = from c in sc.Spends
							select c.Month;
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
				case "totalspend":
				  ret[0] = from c in sc.Spends
							select c.TotalSpend;
				break;
				
				default:
				  ret[0] = from c in sc.Spends
							select c.Month;
				break;
			}
			
			//Get linq query for YVal
			switch(y)
			{
				case "month":
				  ret[1] = from c in sc.Spends
							select c.Month;
				break;
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
							select c.Month;
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
				case "spend":
				case "totalspend":
				  ret[1] = from c in sc.Spends
							select c.TotalSpend;
				break;
				default:
				  ret[1] = from c in sc.Spends
							select c.TotalSpend;
				break;
			}
							
			return ret;
		}
    }
}