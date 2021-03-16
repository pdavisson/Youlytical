using Microsoft.EntityFrameworkCore;
using Youlytical.Models.CRMModels;


namespace CRM.Data
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<ContactData> crmContacts { get; set; }
        public DbSet<PhoneData> crmAddresses { get; set; }
        public DbSet<EmailData> crmEmails { get; set; }
        public DbSet<AddressData> crmPhoneNumbers { get; set; }



        // public DbSet<ContactsModel> crmContacts { get; set; }
        // public DbSet<AddressModel> crmAddresses { get; set; }
        // public DbSet<EmailAccountsModel> crmEmails { get; set; }
        // public DbSet<PhoneNumbersModel> crmPhoneNumbers { get; set; }
    }
}