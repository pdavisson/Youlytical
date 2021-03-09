
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRM.Models;
using CRM.Models.AdminModels;

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
                var list = _context.Users
                    .Join(_context.UserRoles,
                            u => u.Id,
                            ur => ur.UserId,
                            (u,ur) => new
                                {
                                    UID = u.Id,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    Email = u.Email,
                                    Company = u.Company,
                                    Franchise = u.FranchiseID,
                                    RoleId = ur.RoleId
                                })
                    .Join(_context.Roles,
                            a =>a.RoleId,
                            b => b.Id,
                            (a,b) => new ManageUsersModel
                                {
                                    GUID = a.UID,
                                    Profile = "/img/Profile_Pictures/" + a.UID + ".png",
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    Email = a.Email,
                                    Company = a.Company,
                                    Franchise = a.Franchise,
                                    Role = b.Name
                                })
                    .Where(a =>a.Company==user.Company)
                    .ToList();
                ViewBag.UserData=list;
                return View();
            }
            else
            {
                _logger.LogInformation("User logged in is Manager.");
                        var list = _context.Users
                    .Join(_context.UserRoles,
                            u => u.Id,
                            ur => ur.UserId,
                            (u,ur) => new
                                {
                                    UID = u.Id,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    Email = u.Email,
                                    Company = u.Company,
                                    Franchise = u.FranchiseID,
                                    RoleId = ur.RoleId
                                })
                    .Join(_context.Roles,
                            a =>a.RoleId,
                            b => b.Id,
                            (a,b) => new ManageUsersModel
                                {
                                    GUID = a.UID,
                                    
                                    Profile = "/img/Profile_Pictures/" + a.UID + ".png",
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    Email = a.Email,
                                    Company = a.Company,
                                    Franchise = a.Franchise,
                                    Role = b.Name
                                })
                    .Where(a=>a.Company==user.Company && a.Franchise==user.FranchiseID)
                    .ToList();
                ViewBag.UserData=list;
            }

            return View();
		}
        // [Authorize(Roles ="Manager, Admin")]
        // public IActionResult EditUser()
        // {

        // }
    }
}