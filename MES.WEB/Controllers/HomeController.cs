using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MES.Web.Models;
using Microsoft.AspNetCore.Hosting;
using MES.Web.Model;
using Microsoft.AspNetCore.Http;

namespace MES.Web.Controllers
{
    public class HomeController : BaseController
    {
        //MesContext _context = new MesContext();

        private readonly ILogger<HomeController> _logger;
        private IApplicationLifetime ApplicationLifetime { get; set; }

        public HomeController(ILogger<HomeController> logger, IApplicationLifetime appLifetime)
        {
            _logger = logger;
            //ApplicationLifetime = appLifetime;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Subjects(string term)
        //{
        //    var result = _context.KNOWLEDGE_MANAGEMENT
        //       .Where(s => s.SUBJECT.ToLower().Contains(term.ToLower()))
        //       .OrderBy(s => s.SUBJECT)
        //       .Select(s => s.SUBJECT).Take(10)
        //       .ToArray();

        //    return new JsonResult(result);
        //}

        public IActionResult Shutdown()
        {
            ApplicationLifetime.StopApplication();
            return Content("Done");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
