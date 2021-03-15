using System;
using System.ComponentModel.DataAnnotations;
using Youlytical.Models.CRMModels;

namespace Youlytical.Models.CRMModels
{
    public class EmailAccountsModel
    {
        [Key]
        public int eID { get; set; }
        public int ContactID { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string EmailType { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool Primary { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTimeStamp { get; set; }
    }
}