using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRM.Models;

namespace CRM.Controllers
{
    public class CRMController : Controller
    {
        private readonly ILogger<CRMController> _logger;

		public CRMController(ILogger<CRMController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Contacts()
		{
			return View();
		}
    }
}