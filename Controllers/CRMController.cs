using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.CRMModels;
using CRM.Models;
using CRM.Data;
using System.Threading.Tasks;

namespace CRM.Controllers
{
	[Authorize]
    public class CRMController : Controller
    {
		private readonly CRMDbContext _context;
	    private readonly ILogger<CRMController> _logger;
		private readonly UserManager<ApplicationUser> _userManager;
		public string ReturnUrl { get; set; }
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
            var list=_context.crmContacts.Where(a=>a.UserId==UserID).ToList();
			ViewBag.ContactData=list;
            // return View(_context.CRM_Contacts.Where(a=>a.UserId==UserID).ToList());
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateContact(ContactsModel model, string returnUrl = null)
		{
			if(ModelState.IsValid)
			{
				_logger.LogInformation("Model State is Valid.");
				ContactsModel newContact = new ContactsModel()
				{
					UserId=_userManager.GetUserId(HttpContext.User),
					Prefix=model.Prefix,
					FirstName=model.FirstName,
					LastName=model.LastName,
					Suffix=model.Suffix,
					Spouse_Name=model.Spouse_Name,
					PrimaryPhone=model.PrimaryPhone,
					SecondaryPhone=model.SecondaryPhone,
					PrimaryEmail=model.PrimaryEmail,
					SecondaryEmail=model.SecondaryEmail,
					Address1=model.Address1,
					Address2=model.Address2,
					City=model.City,
					State=model.State,
					Zip=model.Zip,	
					Country=model.Country,
					Province=model.Province,
					Tags=model.Tags,
					PreferredContact=model.PreferredContact
				};
				try
				{
					_context.Add(newContact);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Contacts));
				}
				catch
				{
					return RedirectToAction("Contacts","CRM");
				}

			}
			return Redirect(Url.Content("~/"));
		}

    }
}