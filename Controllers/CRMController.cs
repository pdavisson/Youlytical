using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Youlytical.Models.CRMModels;
using CRM.Models;
using CRM.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

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
		// public IActionResult CreateEditContact()
		// {
		// 	return View();
		// }
		
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
		[HttpGet]
		public IActionResult ModalRecord(int ContactID)
		{
			var contact = _context.crmContacts
				.Where(c=>c.ContactID==ContactID)
				.Include(p=>p.PhoneNumbers)
				.Include(e=>e.EmailAddresses)
				.Include(a=>a.Addresses)
				.ToList();
			return Json(contact);
		}
		[HttpPost, ValidateAntiForgeryToken]
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
					if(model.PhoneData != null)
					{
						for(int i = 0; i < model.PhoneData.Count; i++)
						{
							if(model.PhoneData[i].PhoneNumber != null)
							{
								PhoneData newPhone=new PhoneData()
								{
									ContactID=id,
									PhoneType=model.PhoneData[i].PhoneType,
									PhoneNumber=model.PhoneData[i].PhoneNumber,
									Primary=model.PhoneData[i].Primary
								};
							_context.Add(newPhone);
							await _context.SaveChangesAsync();
							}
						}
					}
					if(model.AddressData != null)
					{
						for(int i=0; i < model.AddressData.Count; i++)
						{
							if(model.AddressData[i].Address1 != null)
							{
								AddressData newAddress = new AddressData()
								{
									ContactID=id,
									AddressType=model.AddressData[i].AddressType,
									Address1=model.AddressData[i].Address1,
									Address2=model.AddressData[i].Address2,
									City=model.AddressData[i].City,
									State=model.AddressData[i].State,
									Zip=model.AddressData[i].Zip,
									Country=model.AddressData[i].Country,
									Province=model.AddressData[i].Province,
									Primary=model.AddressData[i].Primary
								};
								_context.Add(newAddress);
								await _context.SaveChangesAsync();
							}
						}
					}
					if(model.EmailData != null)
					{
						for(int i=0; i < model.EmailData.Count; i++)
						{
							if(model.EmailData[i].Email != null)
							{
								EmailData newEmail = new EmailData()
								{
									ContactID=id,
									EmailType=model.EmailData[i].EmailType,
									Email=model.EmailData[i].Email,
									Primary=model.EmailData[i].Primary
								};
								_context.Add(newEmail);
								await _context.SaveChangesAsync();
							}
						}
					}
					return RedirectToAction(nameof(Contacts));
				}
				catch (Exception error)
				{
					Console.WriteLine("Error:" + error);
					return RedirectToAction("Contacts","CRM");
				}
			}
			return Redirect(Url.Content("~/"));
		}
		public async Task<IActionResult> EditContact(ContactsModel model)
		{
			if(ModelState.IsValid){
				try{
					ContactData newContact = new ContactData()
					{
						ContactID=model.ContactData.ContactID,
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
					_context.Update(newContact);
					await _context.SaveChangesAsync();

					if(model.PhoneData != null)
					{
						for(int i = 0; i < model.PhoneData.Count; i++)
						{
							if(model.PhoneData[i].PhoneNumber != null)
							{
								PhoneData newPhone=new PhoneData()
								{
									ContactID=model.ContactData.ContactID,
									pID=model.PhoneData[i].pID,
									PhoneType=model.PhoneData[i].PhoneType,
									PhoneNumber=model.PhoneData[i].PhoneNumber,
									Primary=model.PhoneData[i].Primary
								};
							_context.Update(newPhone);
							await _context.SaveChangesAsync();
							}
						}
					}
					if(model.AddressData != null)
					{
						for(int i=0; i < model.AddressData.Count; i++)
						{
							if(model.AddressData[i].Address1 != null)
							{
								AddressData newAddress = new AddressData()
								{
									ContactID=model.ContactData.ContactID,
									aID=model.AddressData[i].aID,
									AddressType=model.AddressData[i].AddressType,
									Address1=model.AddressData[i].Address1,
									Address2=model.AddressData[i].Address2,
									City=model.AddressData[i].City,
									State=model.AddressData[i].State,
									Zip=model.AddressData[i].Zip,
									Country=model.AddressData[i].Country,
									Province=model.AddressData[i].Province,
									Primary=model.AddressData[i].Primary
								};
								_context.Update(newAddress);
								await _context.SaveChangesAsync();
							}
						}
					}
					if(model.EmailData != null)
					{
						for(int i=0; i < model.EmailData.Count; i++)
						{
							if(model.EmailData[i].Email != null)
							{
								EmailData newEmail = new EmailData()
								{
									ContactID=model.ContactData.ContactID,
									eID=model.EmailData[i].eID,
									EmailType=model.EmailData[i].EmailType,
									Email=model.EmailData[i].Email,
									Primary=model.EmailData[i].Primary
								};
								_context.Update(newEmail);
								await _context.SaveChangesAsync();
							}
						}
					}
					return RedirectToAction(nameof(Contacts));
				}
				catch
				{
					Console.WriteLine("Test");
				}
			}
			return RedirectToAction("Contacts","CRM");
		}
		public async Task<IActionResult> DeleteEmail(int id)
		{
			try
			{
				if(id!=0)
				{
					var record = new EmailData()
					{
						eID = id
					};
					_context.Remove(record);
					await _context.SaveChangesAsync();
					return Json(new { success = true});
				}
			}
			catch(Exception x)
			{
				_logger.LogError(x.Message);
				// Console.WriteLine(x.Message);
			}
			return new EmptyResult();
		}
		public async Task<IActionResult> DeleteAddress(int id)
		{
			try
			{
				if(id!=0)
				{
					var record = new AddressData()
					{
						aID = id
					};
					_context.Remove(record);
					await _context.SaveChangesAsync();
				}
				return Json(new { success = true});
			}
			catch(Exception x)
			{
				_logger.LogError(x.Message);
			}
			Console.WriteLine("CALLED THE CORRECT IACTIONRESULT YAY!!!! yeah!!!");
			return new EmptyResult();
		}
		public async Task<IActionResult> DeletePhone(int id)
		{
			try
			{
				if(id != 0)
				{
					var record = new PhoneData()
					{
						pID = id
					};
					_context.Remove(record);
					await _context.SaveChangesAsync();
				}
				return Json(new { success = true});
			}
			catch(Exception x)
			{
				_logger.LogError(x.Message);
			}
			Console.WriteLine("CALLED THE CORRECT IACTIONRESULT YAY!!!! yeah!!!");
			return new EmptyResult();
		}
    }
}