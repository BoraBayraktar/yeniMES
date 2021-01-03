using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MES.Web.Models
{
	public class LdapViewModel
	{
		public LdapViewModel()
		{
			LdapOus = new List<LdapOuModel>();
		}
		public int Id { get; set; }
		public string ServerAddress { get; set; }
		public int PortNumber { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string SearchBase { get; set; }
		public string CronType { get; set; }
		public TimeSpan DailyTime { get; set; }
		public int DayOfWeek { get; set; }
		public int DayOfMonth { get; set; }
		public DateTime OneTime { get; set; }
		public string SelectedOu { get; set; }
		public string SelectedOuModels { get; set; }
		public List<LdapOuModel> LdapOus { get; set; }
		public List<SelectListItem> DayOfWeekInit { get; set; }
	}

	public class LdapOuModel
	{
		public string OuName { get; set; }
		public List<string> IdentifierName { get; set; }
		public string  IdentifierNameToString { get; set; }
	}
}
