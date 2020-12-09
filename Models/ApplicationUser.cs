using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CRM.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Company { get; set; }
        public string FranchiseID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
