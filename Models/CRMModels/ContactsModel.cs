using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Youlytical.Models.CRMModels
{
    public class ContactsModel
    {
        public ContactData ContactData { get; set; }
        public PhoneData PhoneData { get; set; }
        public EmailData EmailData { get; set; }
        public AddressData AddressData { get; set; }
    }
    public class ContactData
    {
        private DateTime _createdon = DateTime.Now;
        [Key]        
        public int ContactID { get; set; }
        
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
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string SpousePrefix { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string SpouseFirstName { get; set; }
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string SpouseLastName  { get; set; }
        [StringLength(10)]
        [DataType(DataType.Text)]
        public string SpouseSuffix { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Create_DateTimeStamp { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdate_DateTimeStamp { get; set; }
        public virtual List<PhoneData> PhoneNumbers { get; set; }
        public virtual ICollection<EmailData> EmailAddresses { get; set; }
        public virtual List <AddressData> Addresses { get; set; }
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
    }

    public class EmailData
    {   
        [Key]
        public int eID { get; set; }
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public ContactData ContactData { get; set; }
        
        [BindProperty]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string EmailType { get; set; }
        // public virtual ICollection<EmailData> Email { get; set; }
        // internal void CreateEmailArray(int count =1)
        // {
        //     for(int i=0; i< count; i++) {
        //         Email.Add(new EmailData()); 
        //     }
        // }
        [EmailAddress]
        public string Email { get; set; }
        public bool Primary { get; set; }
    }

    public class AddressData
    {
        [Key]
        public int aID { get; set; }
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public ContactData ContactData { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        public string AddressType { get; set; }

        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Address1 { get; set; }
        
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string Address2 { get; set; }

        [StringLength(100)]
        [DataType(DataType.Text)]
        public string City { get; set; }

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
    }
}