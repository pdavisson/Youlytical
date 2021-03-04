using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models.AdminModels
{
    public class ManageUsersModel
    {
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Company { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Franchise { get; set; }
        [StringLength(256)]
        [DataType(DataType.Text)]
        public string Role { get; set; }
    }
}


