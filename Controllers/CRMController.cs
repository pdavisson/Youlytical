using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace CRM.Controllers
{
	[Authorize]
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