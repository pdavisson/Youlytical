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
        public DbSet<PhoneData> crmPhoneNumbers { get; set; }
        public DbSet<EmailData> crmEmails { get; set; }
        public DbSet<AddressData> crmAddresses { get; set; }


    }
}