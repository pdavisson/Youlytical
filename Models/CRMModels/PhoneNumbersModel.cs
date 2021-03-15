using System;
using System.ComponentModel.DataAnnotations;
using Youlytical.Models.CRMModels;

namespace Youlytical.Models.CRMModels
{
    public class PhoneNumbersModel
    {
        [Key]
        public int phID { get; set; }
        public int ContactID { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        public string PhoneType { get; set; }

        [EmailAddress]
        public string Phone { get; set; }
        public bool Primary { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTimeStamp { get; set; }
    }
}