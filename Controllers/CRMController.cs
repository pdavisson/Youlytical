using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CRM.Data;
using System.Linq;

namespace CRM.Controllers
{
	[Authorize]
    public class CRMController : Controller
    {
		private readonly CRMDbContext _context;
	    private readonly ILogger<CRMController> _logger;

		public CRMController(ILogger<CRMController> logger, CRMDbContext context)
		{
			_logger = logger;
			_context=context;

		}
		
		public IActionResult Index()
		{
			return View();
		}
		
        public IActionResult Contacts()
		{
			return View(_context.CRM_Contacts.ToList());
		}
		

    }
}