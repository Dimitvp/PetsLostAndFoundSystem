using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetsLostAndFoundSystem.MVC.Models;
using PetsLostAndFoundSystem.MVC.Services.Contracts;

namespace PetsLostAndFoundSystem.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReportService reports;

        public HomeController(ILogger<HomeController> logger, IReportService reports)
        {
            _logger = logger;
            this.reports = reports;
        }

        public async Task<IActionResult> Index()
            => View(await this.reports.All());

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
