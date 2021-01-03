using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Web.Model
{
	public class LDAP_INFO : BASE
	{
		public int Id { get; set; }
		public string ServerAddress { get; set; }
		public int PortNumber { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string SearchBase { get; set; }
		public string  CronType { get; set; }
		public TimeSpan DailyTime { get; set; }
		public int DayOfWeek { get; set; }
		public int DayOfMonth { get; set; }
		public DateTime  OneTime { get; set; }
		public string SelectedOu { get; set; }
	}
}
