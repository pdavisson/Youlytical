using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Youlytical.Models.CRMModels
{
    public class ContactData
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
        public List<PhoneData> PhoneNumbers { get; set; }
        public List<EmailData> EmailAddresses { get; set; }
        public List <AddressData> Addresses { get; set; }

    }

    public class PhoneData
    {
        [Key]
        public int pID { get; set; }
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public ContactData ContactData { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        public string PhoneType { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public bool Primary { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTimeStamp { get; set; }
    }

    public class EmailData
    {   
        [Key]
        public int eID { get; set; }
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public ContactData ContactData { get; set; }
        
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

    public class AddressData
    {
        [Key]
        public int aID { get; set; }
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public ContactData ContactData { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string AddressType { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Address1 { get; set; }
        
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string State { get; set; }

        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Zip { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Country { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Province { get; set; }

        public bool Primary { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTimeStamp { get; set; }
    }
}