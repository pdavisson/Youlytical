using Microsoft.EntityFrameworkCore;
using Models.CRMModels;

namespace CRM.Data
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<ContactsModel> CRM_Contacts { get; set; }
    }
}