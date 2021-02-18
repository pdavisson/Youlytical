using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CRM.Models;
using CRM.Data;


namespace CRM.Controllers
{
	[Authorize]
    public class CRMController : Controller
    {
		private readonly CRMDbContext _context;
	    private readonly ILogger<CRMController> _logger;
		private readonly UserManager<ApplicationUser> _userManager;

		public CRMController(ILogger<CRMController> logger, CRMDbContext context, UserManager<ApplicationUser> userManager)
		{
			_logger = logger;
			_context=context;
			_userManager=userManager;

		}
		
		public IActionResult Index()
		{
			return View();
		}
		
        public IActionResult Contacts()
		{
			var UserID=_userManager.GetUserId(HttpContext.User);
            var list=_context.CRM_Contacts.Where(a=>a.UserId==UserID).ToList();
			ViewBag.ContactData=list;
            // return View(_context.CRM_Contacts.Where(a=>a.UserId==UserID).ToList());
			return View();
		}
		

    }
}