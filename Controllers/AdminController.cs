
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CRM.Services;
using CRM.Data;
using System.Linq;

namespace CRM.Controllers 
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        public AdminController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AdminController> logger,
            ApplicationDbContext context)            
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _context = context;
        }
        [Authorize(Roles ="Manager, Admin")]
        public IActionResult ManageUsers()
		{
            var UserID=_userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(UserID).Result;
            if(HttpContext.User.IsInRole("Admin"))
            {
                _logger.LogInformation("User logged in is Admin.");
                var list = _context.Users.Where(a=>a.Company==user.Company).ToList();
                ViewBag.ContactData=list;
            }
            else
            {
                _logger.LogInformation("User logged in is Manager.");
                var list = _context.Users.Where(a=>a.Company==user.Company && a.FranchiseID==user.FranchiseID).ToList();
                ViewBag.ContactData=list;
            }

            return View();
		}
    }
}