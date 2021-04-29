using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Youlytical.Models.CRMModels;
using CRM.Models;
using CRM.Data;
using System.Threading.Tasks;
using CRM.Services;
using Microsoft.EntityFrameworkCore;



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
		public IActionResult Test()
		{
			return View();
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult CreateEditContact()
		{
			return View();
		}
		
        public IActionResult Contacts()
		{
			var UserID=_userManager.GetUserId(HttpContext.User);
            var ContactList=_context.crmContacts
				.Include(b=>b.PhoneNumbers)
				.Include(p=>p.EmailAddresses)
				.Include(c=>c.Addresses)
				.Where(a=>a.UserId==UserID)
				.ToList();
			ViewBag.ContactList=ContactList;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		// public async Task<IActionResult> CreateContact(ContactData mContact, PhoneData mPhone, EmailData mEmail, AddressData mAddress, string returnUrl = null)
		public async Task<IActionResult> CreateContact(ContactsModel model, string returnUrl = null)
		{
			if(ModelState.IsValid)
			{
				try
				{
					_logger.LogInformation("Model State is Valid.");
					ContactData newContact = new ContactData()
					{
						UserId=_userManager.GetUserId(HttpContext.User),
						
						Prefix=model.ContactData.Prefix,
						FirstName=model.ContactData.FirstName,
						LastName=model.ContactData.LastName,
						Suffix=model.ContactData.Suffix,
						SpousePrefix=model.ContactData.SpousePrefix,
						SpouseFirstName=model.ContactData.SpouseFirstName,
						SpouseLastName=model.ContactData.SpouseLastName,
						SpouseSuffix=model.ContactData.SpouseSuffix,
						Create_DateTimeStamp=System.DateTime.Now,
						LastUpdate_DateTimeStamp=System.DateTime.Now
					};
					_context.Add(newContact);
					await _context.SaveChangesAsync();
					int id = newContact.ContactID;
					PhoneData newPhone = new PhoneData()
					{
						ContactID=id,
						PhoneType=model.PhoneData.PhoneType,
						PhoneNumber=model.PhoneData.PhoneNumber,
						Primary=model.PhoneData.Primary
					};
					AddressData newAddress = new AddressData()
					{
						ContactID=id,
						// AddressType=mAddress.AddressType,
						AddressType="Test",
						Address1=model.AddressData.Address1,
						Address2=model.AddressData.Address2,
						City=model.AddressData.City,
						State=model.AddressData.State,
						Zip=model.AddressData.Zip,
						Country=model.AddressData.Country,
						Province=model.AddressData.Province,
						Primary=model.AddressData.Primary
					};
					// EmailData newEmail = new EmailData()
					// {
					// 	foreach (var Entry in newEmail)
					// 	{
					// 	ContactID=id,
					// 	EmailType=model.EmailData[Entry].EmailType,
					// 	Email=model.EmailData[].Email,
					// 	Primary=model.EmailData[].Primary
					// 	}
		
					// };
					_context.Add(newPhone);
					_context.Add(newAddress);
					// _context.Add(newEmail);
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