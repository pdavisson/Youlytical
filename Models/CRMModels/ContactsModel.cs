using System;
using System.ComponentModel.DataAnnotations;

namespace CRMModels
{
    public class ContactsModel
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string prefix { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string First { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Last { get; set; }
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string Suffix { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Spouse_Name { get; set; }
        [Required]
        [Phone]
        [StringLength(50)]
        [Display(Name = "Primary Phone Number")]
        public string PrimaryPhone { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Secondary Phone")]
        public string SecondaryPhone { get; set; }
        [EmailAddress]
        public string PrimaryEmail { get; set; }
        [EmailAddress]
        public string SecondaryEmail { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Country { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string province { get; set; }
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Address1 { get; set; }
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Address2 { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string City { get; set; }
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string State { get; set; }
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Zip { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Tags { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string PreferredContact { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EntryDateTimeStamp { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdate_DateTimeStamp { get; set; }
    }
}