using System;
using System.ComponentModel.DataAnnotations;

namespace Youlytical.Models.CRMModels
{
    public class ContactsModel
    {
        [Key]
        public int ContactID { get; set; }
        // [Required]
        [StringLength(450)]
        [DataType(DataType.Text)]
        public string UserId { get; set; }
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string Prefix { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string Suffix { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string SpouseFirstName { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string SpouseLastName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdate_DateTimeStamp { get; set; }
    }

}